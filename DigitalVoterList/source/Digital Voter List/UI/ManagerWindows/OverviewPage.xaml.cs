﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using UI.Data;

namespace UI.ManagerWindows
{
    /// <summary>
    /// Interaction logic for OverviewPage.xaml
    /// </summary>
    public partial class OverviewPage
    {
        private readonly Frame _parent;
        private readonly UiHandler _ui;
        private Thread _activeUpdateThread;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="parent">the frame this page is shown in</param>
        /// <param name="ui">the UIHandler for this UI</param>
        public OverviewPage(Frame parent, UiHandler ui)
        {
            InitializeComponent();
            _parent = parent;
            _ui = ui;
            _ui.OverviewPage = this;
            LoadingBar.Visibility = Visibility.Hidden;
            LoadingBar.Value = 100;
            PopulateList();
        }

        /// <summary>
        /// Called when the remove button is clicked
        /// </summary>
        /// <param name="sender">autogenerated</param>
        /// <param name="e">autogenerated</param>
        private void RemoveButtonClick(object sender, RoutedEventArgs e)
        {
            if (stationGrid.SelectedItem != null)
            {
                if (((StationStatus)stationGrid.SelectedItem).Connected)
                {
                    _ui.RemoveStation(((StationStatus)stationGrid.SelectedItem).IpAdress);
                    UnmarkConnected(new IPEndPoint(IPAddress.Parse(((StationStatus)stationGrid.SelectedItem).IpAdress), 62000));
                    PopulateList();
                }
            }
        
        }

        /// <summary>
        /// Called when the Add button is clicked
        /// </summary>
        /// <param name="sender">autogenerated</param>
        /// <param name="e">autogenerated</param>
        private void AddButtonClick(object sender, RoutedEventArgs e)
        {
            if (stationGrid.SelectedCells.Count != 0)
                _ui.ExchangeKeys(new IPEndPoint(IPAddress.Parse(((StationStatus) stationGrid.SelectedItem).IpAdress),62000)); 
        }

        /// <summary>
        /// Called when the back button is clicked
        /// </summary>
        /// <param name="sender">autogenerated</param>
        /// <param name="e">autogenerated</param>
        private void BackButtonClick(object sender, RoutedEventArgs e)
        {
            if (_activeUpdateThread != null)
                _activeUpdateThread.Abort();

            _parent.Navigate(new DataLoadPage(_parent, _ui));
            _ui.DisposeStation();
            _ui.OverviewPage = null;
        }

        /// <summary>
        /// Called when the start election button is clicked 
        /// </summary>
        /// <param name="sender">autogenerated</param>
        /// <param name="e">autogenerated</param>
        private void StartEndElectionButtonClick(object sender, RoutedEventArgs e)
        {
            if(!_ui.EnoughStations())
            {
                MessageBox.Show("Du er ikke forbundet til nok stationer", "Ikke nok stationer", MessageBoxButton.OK,
                                MessageBoxImage.Information);
                return;
            }
                

            var d = new CheckMasterPasswordDialog(_ui);
            d.ShowDialog();

            if (d.DialogResult.HasValue && d.DialogResult == true)
            {
                if (d.IsCancel)
                    return;

                if (_activeUpdateThread != null)
                    _activeUpdateThread.Abort();
                

                _ui.OverviewPage = null;
                _ui.ManagerAnnounceStartElection();
                _parent.Navigate(new ManagerOverviewPage(_parent, _ui));
            }
            else
            {
                MessageBox.Show("Det kodeord du indtastede er ikke korrekt, prøv igen", "Forkert master kodeord", MessageBoxButton.OK);
            }
        }

        /// <summary>
        /// Populates this lists with the appropiate stations
        /// </summary>
        public void PopulateList()
        {
            if(_activeUpdateThread != null)
                _activeUpdateThread.Abort();
            RefreshButton.IsEnabled = false;
            Thread oThread = new Thread(() => PopulateListThread(this));
            _activeUpdateThread = oThread;
            oThread.Start();
        }

        /// <summary>
        /// The thread that updates the list
        /// </summary>
        /// <param name="ovp">this overview page</param>
        public void PopulateListThread(OverviewPage ovp)
        {
            ovp.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal, new Action(delegate { UpdateLabel.Content = "Opdaterer..."; }));
            ovp.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal, new Action(delegate { LoadingBar.Visibility = Visibility.Visible;}));
            IEnumerable<IPEndPoint> peerlist = _ui.GetPeerlist();

            if (peerlist != null)
            {
                var dataSource = (from ip in peerlist where _ui.IsStationActive(ip) select new StationStatus { IpAdress = ip.Address.ToString(), Connected = true }).ToList();
                dataSource.AddRange(from ip in _ui.DiscoverPeers() where !peerlist.Contains(ip) select new StationStatus { IpAdress = ip.Address.ToString(), Connected = false });

                ovp.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal, new Action(delegate { stationGrid.ItemsSource = dataSource; }));
                ovp.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal, new Action(delegate { stationGrid.Items.Refresh(); }));
            }
            ovp.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal, new Action(delegate { UpdateLabel.Content = ""; }));
            ovp.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal, new Action(delegate { LoadingBar.Visibility = Visibility.Hidden; }));
            ovp.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal, new Action(delegate { RefreshButton.IsEnabled = true; }));

        }

        /// <summary>
        /// After this manager tries to connect to a station, the station replies.
        /// This method is called when the reply is received.
        /// </summary>
        /// <param name="ip"> the IP adress of the replying station</param>
        /// <returns> the password the user has typed in the AcceptStationDialog</returns>
        public string IncomingReply(IPEndPoint ip)
        {
            var acd = new AcceptStationDialog(ip, _ui);
            var result = acd.ShowDialog();

            if (result.HasValue && result == true)
            {
                return acd.TypedPassword;
            }

            return "";
        }

        /// <summary>
        /// Called when the refresh button is clicked
        /// </summary>
        /// <param name="sender">autogenerated</param>
        /// <param name="e">autogenerated</param>
        private void RefreshButtonClick(object sender, RoutedEventArgs e)
        {
                PopulateList();
        }

        /// <summary>
        /// Sets the password label
        /// </summary>
        /// <param name="content">the string to set the label to</param>
        public void SetPasswordLabel(string content)
        {
            PasswordLabel.Content = content;
        }

        /// <summary>
        /// Marks a station as connected in the list
        /// </summary>
        /// <param name="ip">the IP address of the station to mark</param>
        public void MarkAsConnected(IPEndPoint ip)
        {
            foreach (StationStatus s in stationGrid.Items)
            {
                if (s.IpAdress == ip.Address.ToString())
                    s.Connected = true;
            }
            stationGrid.Items.Refresh();
        }

        /// <summary>
        /// Unmark a connected station in the list
        /// </summary>
        /// <param name="ip">the IP address of the station to unmark</param>
        public void UnmarkConnected(IPEndPoint ip)
        {
            foreach (StationStatus s in stationGrid.Items)
            {
                if (s.IpAdress == ip.Address.ToString())
                    s.Connected = false;
            }
            stationGrid.Items.Refresh();
        }

        private void StationGridSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(((StationStatus) stationGrid.SelectedItem).Connected)
            {
                AddButton.IsEnabled = false;
                RemoveButton.IsEnabled = true;
            }else
            {
                AddButton.IsEnabled = true;
                RemoveButton.IsEnabled = false;
            }
        }
    }
}
