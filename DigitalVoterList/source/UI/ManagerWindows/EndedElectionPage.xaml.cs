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
  using System.Windows.Forms;
  using System.Windows.Controls;
  using System.Threading;

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
      _parent = parent;
      _ui = ui;
      var wnd = (StationWindow)Window.GetWindow(_parent);
      if (wnd != null) {
        wnd.Width = 600;
        wnd.ExitMenuItem.IsEnabled = false;
        wnd.ExportDataMenuItem.IsEnabled = false;
      }

      InitializeComponent();
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
      if (filePathTextbox.Text.Length > 0) {
        _ui.ExportData(filePathTextbox.Text);
        Thread.Sleep(10000);
        Environment.Exit(0);
      } else FlexibleMessageBox.Show("You have not selected an output file path.", "No File Path", MessageBoxButtons.OK);
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
      var saveDialog = new Microsoft.Win32.SaveFileDialog { Title = "Export Election Data" };
      saveDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
      saveDialog.ShowDialog();

      filePathTextbox.Text = saveDialog.FileName;

      if (!filePathTextbox.Text.Equals(string.Empty)) ExportButton.IsEnabled = true;
    }

    #endregion
  }
}
