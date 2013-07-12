﻿#region Copyright and License

// // -----------------------------------------------------------------------
// // <copyright file="StationStatus.cs" company="DemTech">
// // Copyright (C) 2013 Joseph Kiniry, DemTech, 
// // IT University of Copenhagen, Technical University of Denmark,
// // Nikolaj Aaes, Nicolai Skovvart
// // </copyright>
// // -----------------------------------------------------------------------
#endregion

namespace UI.Data {
  /// <summary>
  /// The station status.
  /// </summary>
  public class StationStatus {
    #region Public Properties

    /// <summary>
    /// Gets or sets a value indicating whether connected.
    /// </summary>
    public bool Connected { get; set; }

    /// <summary>
    /// Gets or sets the ip adress.
    /// </summary>
    public string IpAdress { get; set; }

    #endregion
  }
}
