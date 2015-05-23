﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EndedElectionPage.xaml.cs" company="">
//   
// </copyright>
// <summary>
//   Interaction logic for EndedElectionPage.xaml
// </summary>
// --------------------------------------------------------------------------------------------------------------------

#region Copyright and License

// // -----------------------------------------------------------------------
// // <copyright file="EndedElectionPage.xaml.cs" company="DemTech">
// // Copyright (C) 2013 Joseph Kiniry, DemTech, 
// // IT University of Copenhagen, Technical University of Denmark,
// // Nikolaj Aaes, Nicolai Skovvart
// // </copyright>
// // -----------------------------------------------------------------------
#endregion

namespace UI.ManagerWindows {
  using System;
  using System.Windows;
  using System.Windows.Controls;

  using Microsoft.Win32;

  /// <summary>
  /// Interaction logic for EndedElectionPage.xaml
  /// </summary>
  public partial class EndedElectionPage {
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
    /// Initializes a new instance of the <see cref="EndedElectionPage"/> class. 
    /// Constructor
    /// </summary>
    /// <param name="parent">
    /// the frame this page is displayed in
    /// </param>
    /// <param name="ui">
    /// the UIHandler for this UI
    /// </param>
    public EndedElectionPage(Frame parent, UiHandler ui) {
      this._parent = parent;
      this._ui = ui;
      var wnd = (StationWindow)Window.GetWindow(this._parent);
      if (wnd != null) {
        wnd.Width = 600;
        wnd.ExitMenuItem.IsEnabled = false;
        wnd.ExportDataMenuItem.IsEnabled = false;
      }

      this.InitializeComponent();
    }

    #endregion

    #region Methods

    /// <summary>
    /// Called when the export button is clicked
    /// </summary>
    /// <param name="sender">
    /// autogenerated
    /// </param>
    /// <param name="e">
    /// autogenerated
    /// </param>
    private void ExportButtonClick(object sender, RoutedEventArgs e) {
      if (this.filePathTextbox.Text.Length > 0) {
        this._ui.ExportData(this.filePathTextbox.Text);
        Environment.Exit(0);
      } else MessageBox.Show("Du har ikke valgt en fil sti", "Ingen fil sti", MessageBoxButton.OK);
    }

    /// <summary>
    /// Called when the browse button is clicked
    /// </summary>
    /// <param name="sender">
    /// autogenerated
    /// </param>
    /// <param name="e">
    /// autogenerated
    /// </param>
    private void FileBrowseButtonClick(object sender, RoutedEventArgs e) {
      var saveDialog = new SaveFileDialog { Title = "Eksporter Valg Data" };
      saveDialog.Filter = "Data files (*.data)|*.data|All files (*.*)|*.*";
      saveDialog.ShowDialog();

      this.filePathTextbox.Text = saveDialog.FileName;

      if (!this.filePathTextbox.Text.Equals(string.Empty)) this.ExportButton.IsEnabled = true;
    }

    #endregion
  }
}
