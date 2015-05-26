﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DataLoadPage.xaml.cs" company="">
//   
// </copyright>
// <summary>
//   Interaction logic for DataLoadPage.xaml
// </summary>
// --------------------------------------------------------------------------------------------------------------------

#region Copyright and License

// // -----------------------------------------------------------------------
// // <copyright file="DataLoadPage.xaml.cs" company="DemTech">
// // Copyright (C) 2013 Joseph Kiniry, DemTech, 
// // IT University of Copenhagen, Technical University of Denmark,
// // Nikolaj Aaes, Nicolai Skovvart
// // </copyright>
// // -----------------------------------------------------------------------
#endregion

namespace UI.ManagerWindows {
  using System.Windows;
  using System.Windows.Forms;
  using System.Windows.Controls;
  using System.Threading;
  using System;

  /// <summary>
  /// Interaction logic for DataLoadPage.xaml
  /// </summary>
  public partial class DataLoadPage {
    #region Fields

    /// <summary>
    /// The _parent.
    /// </summary>
    private readonly Frame _parent;

    /// <summary>
    /// The _ui.
    /// </summary>
    private readonly UiHandler _ui;

    #endregion

    #region Constructors and Destructors

    /// <summary>
    /// Initializes a new instance of the <see cref="DataLoadPage"/> class. 
    /// constructor
    /// </summary>
    /// <param name="parent">
    /// the frame in which this page is displayed
    /// </param>
    /// <param name="ui">
    /// the UIHandler for this UI
    /// </param>
    public DataLoadPage(Frame parent, UiHandler ui) {
      this.InitializeComponent();
      this._parent = parent;
      this._ui = ui;
      LoadingLabel.Visibility = System.Windows.Visibility.Hidden;
    }

    #endregion

    #region Methods

    /// <summary>
    /// Called when the back button is clicked
    /// </summary>
    /// <param name="sender">
    /// autogenerated
    /// </param>
    /// <param name="e">
    /// autogenerated
    /// </param>
    private void BackButtonClick(object sender, RoutedEventArgs e) {
      this._parent.Navigate(new TypeChoicePage(this._parent, this._ui));
      this._ui.DisposeStation();
    }

    /// <summary>
    /// Called when the Data browse button is clicked
    /// </summary>
    /// <param name="sender">
    /// autogenerated
    /// </param>
    /// <param name="e">
    /// autogenerated
    /// </param>
    private void FileBrowseButtonClick(object sender, RoutedEventArgs e) {
      // Create OpenFileDialog
      var dlg = new Microsoft.Win32.OpenFileDialog {
        DefaultExt = ".data", 
        Filter = "Data files (.data)|*.data|All Files|*.*", 
      };

      // Display OpenFileDialog by calling ShowDialog method
      var result = dlg.ShowDialog();

      // Get the selected file name and display in a TextBox
      if (result != true) return;

      // Open document
      var filename = dlg.FileName;
      this.filePathTextbox.Text = filename;

      UpdateButtons();
    }

    /// <summary>
    /// Called when the key browser button is clicked
    /// </summary>
    /// <param name="sender">
    /// autogenerated
    /// </param>
    /// <param name="e">
    /// autogenerated
    /// </param>
    private void KeyBrowseButtonClick(object sender, RoutedEventArgs e) {
      // Create OpenFileDialog
      var dlg = new Microsoft.Win32.OpenFileDialog {
        DefaultExt = ".data",
        Filter = "Data files (.data)|*.data|All Files|*.*",
      };

      // Display OpenFileDialog by calling ShowDialog method
      var result = dlg.ShowDialog();

      // Get the selected file name and display in a TextBox
      if (result != true) return;

      // Open document
      var filename = dlg.FileName;
      this.keyPathTextBox.Text = filename;

      UpdateButtons();
    }

    private void BlinkVisibility() {
      while (true) {
        Dispatcher.Invoke(
          System.Windows.Threading.DispatcherPriority.Normal,
          new Action(delegate {
          if (LoadingLabel.IsVisible) {
            LoadingLabel.Visibility = Visibility.Hidden;
          } else {
            LoadingLabel.Visibility = Visibility.Visible;
          }
        }));
        Thread.Sleep(800);
      }
    }

    /// <summary>
    /// Called when the next button is clicked
    /// </summary>
    /// <param name="sender">
    /// autogenerated
    /// </param>
    /// <param name="e">
    /// autogenerated
    /// </param>
    private void NextButtonClick(object sender, RoutedEventArgs e) {
      Thread t = new Thread(new ParameterizedThreadStart(ImportDataThread));
      t.Name = "Import";
      t.SetApartmentState(ApartmentState.STA);
      t.Start(Tuple.Create<string, string>(filePathTextbox.Text, keyPathTextBox.Text));
      backButton.IsEnabled = false;
      nextButton.IsEnabled = false;
    }

    private void ImportDataThread(object parameter) {
      Tuple<string, string> p = parameter as Tuple<string, string>;
      string filePath = p.Item1;
      string keyPath = p.Item2;
      Thread t = new Thread(BlinkVisibility);
      t.Name = "Blinker";
      t.SetApartmentState(ApartmentState.STA);
      t.Start();
      if (_ui.ImportData(filePath, keyPath)) {
        Dispatcher.Invoke(
          System.Windows.Threading.DispatcherPriority.Normal,
          new Action(delegate {
          _parent.Navigate(new PrecinctChoicePage(this._parent, this._ui));
        }));
      } else {
        Dispatcher.Invoke(
          System.Windows.Threading.DispatcherPriority.Normal,
          new Action(delegate {
          FlexibleMessageBox.Show("Could not import data from specified files.", "Import Failed", MessageBoxButtons.OK);
        }));
      }
      t.Abort();
      Dispatcher.Invoke(
        System.Windows.Threading.DispatcherPriority.Normal,
        new Action(delegate {
        LoadingLabel.Visibility = Visibility.Hidden;
        UpdateButtons();
      }));
    }

    private void UpdateButtons() {
      nextButton.IsEnabled = !(filePathTextbox.Text.Equals(string.Empty) || keyPathTextBox.Text.Equals(string.Empty));
      backButton.IsEnabled = true;
    }

    #endregion
  }
}
