﻿#region Copyright and License

// // -----------------------------------------------------------------------
// // <copyright file="VoterListDatabase.cs" company="DemTech">
// // Copyright (C) 2013 Joseph Kiniry, DemTech, 
// // IT University of Copenhagen, Technical University of Denmark,
// // Nikolaj Aaes, Nicolai Skovvart
// // </copyright>
// // -----------------------------------------------------------------------
#endregion

namespace Aegis_DVL.Database {
  using System;
  using System.Collections.Generic;
  using System.Data.Common;
  using System.Data.SQLite;
  using System.Diagnostics.Contracts;
  using System.Linq;

  using Aegis_DVL.Cryptography;
  using Aegis_DVL.Data_Types;
  using Aegis_DVL.Util;

  /// <summary>
  /// The sq lite database.
  /// </summary>
  internal class VoterListDatabase : IDatabase {
    #region Fields

    /// <summary>
    ///   The database, wrapped in an autogenerated Entities.
    /// </summary>
    private readonly Entities _db;

    private const bool PasswordProtectDb = false;

    /// <summary>
    /// The _is disposed.
    /// </summary>
    private bool _isDisposed;

    #endregion

    #region Constructors and Destructors

    /// <summary>
    /// Initializes a new instance of the <see cref="VoterListDatabase"/> class. 
    /// May I have a new SqliteDatabase?
    /// </summary>
    /// <param name="parent">
    /// The parent station of the database.
    /// </param>
    /// <param name="filename">
    /// The name of the file where the data is stored. Defaults to Voters.sqlite.
    /// </param>
    public VoterListDatabase(Station parent, string filename = "Voters.sqlite") {
      Contract.Requires(parent != null);
      Contract.Requires(filename != null);

      this.Parent = parent;
      string password = "";
      if (PasswordProtectDb)
        password = Crypto.GeneratePassword();
      InitDb(filename, password);

      string conStr =
        string.Format(
          "metadata=res://*/Database.VoterModel.csdl|" +
          "res://*/Database.VoterModel.ssdl|" +
          "res://*/Database.VoterModel.msl;" +
          "provider=System.Data.SQLite;" +
          "provider connection string='Data Source={0}", 
          filename);
      if (PasswordProtectDb) conStr += string.Format(";Password={0}'", password);
      else conStr += "'";
      this._db = new Entities(conStr);
      this._db.Connection.Open();
    }

    /// <summary>
    /// Finalizes an instance of the <see cref="VoterListDatabase"/> class. 
    /// </summary>
    ~VoterListDatabase() { this.Dispose(false); }

    #endregion

    #region Public Properties

    /// <summary>
    /// Gets the all data.
    /// </summary>
    public IEnumerable<EncryptedVoterData> AllData {
      get {
        return
          this._db.Voters.ToArray()
              .Select(
                data =>
                new EncryptedVoterData(
                  new CipherText(data.VoterNumber), 
                  new CipherText(data.CPR), 
                  new CipherText(data.BallotStatus)))
              .ToArray();
      }
    }

    /// <summary>
    /// Gets the parent.
    /// </summary>
    public Station Parent { get; private set; }

    #endregion

    #region Public Indexers

    /// <summary>
    /// The this.
    /// </summary>
    /// <param name="voternumber">
    /// The voternumber.
    /// </param>
    /// <returns>
    /// The <see cref="BallotStatus"/>.
    /// </returns>
    /// TODO: review for problems with complexity
    public BallotStatus this[VoterNumber voternumber] {
      get {
        Voter voter = GetVoter(voternumber);
        if (voter == null) return BallotStatus.Unavailable;
        CipherText encVn = this.Parent.Crypto.AsymmetricEncrypt(
          Bytes.From(voternumber.Value), this.Parent.Crypto.VoterDataEncryptionKey);
        if (!voter.VoterNumber.IsIdenticalTo(encVn)) return BallotStatus.Unavailable;
        CipherText encBallotReceived = this.Parent.Crypto.AsymmetricEncrypt(
          Bytes.From((uint)BallotStatus.Received), 
          this.Parent.Crypto.VoterDataEncryptionKey);
        return voter.BallotStatus.IsIdenticalTo(encBallotReceived)
                 ? BallotStatus.Received
                 : BallotStatus.NotReceived;
      }

      set {
        if (this.Parent.Logger != null) {
          this.Parent.Logger.Log(
            "Setting ballotstatus for voternumber=" +
            voternumber + " to " + value, 
            Level.Info);
        }

        Voter voter = GetVoter(voternumber);
        voter.BallotStatus = this.Parent.Crypto.AsymmetricEncrypt(
          Bytes.From((uint)value), this.Parent.Crypto.VoterDataEncryptionKey);
        this._db.SaveChanges();
      }
    }

    /// <summary>
    /// The this.
    /// </summary>
    /// <param name="cpr">
    /// The cpr.
    /// </param>
    /// <param name="masterPassword">
    /// The master password.
    /// </param>
    /// <returns>
    /// The <see cref="BallotStatus"/>.
    /// </returns>
    /// TODO: review for problems with complexity
    public BallotStatus this[CPR cpr, string masterPassword] {
      get {
        CipherText encBallotReceived = this.Parent.Crypto.AsymmetricEncrypt(
          Bytes.From((uint)BallotStatus.Received), this.Parent.Crypto.VoterDataEncryptionKey);
        Voter voter = GetVoter(cpr);
        if (voter == null) return BallotStatus.Unavailable;
        return voter.BallotStatus.IsIdenticalTo(encBallotReceived) ? BallotStatus.Received : BallotStatus.NotReceived;
      }

      set {
        if (this.Parent.Logger != null) {
          this.Parent.Logger.Log(
            "Setting ballotstatus for CPR " + cpr +
            " with master password to " + value, 
            Level.Info);
        }

        Voter voter = GetVoter(cpr);
        voter.BallotStatus = this.Parent.Crypto.AsymmetricEncrypt(
          Bytes.From((uint)value), this.Parent.Crypto.VoterDataEncryptionKey);
        this._db.SaveChanges();
      }
    }

    #endregion

    #region Public Methods and Operators

    /// <summary>
    /// The dispose.
    /// </summary>
    public void Dispose() {
      if (!this._isDisposed) this.Dispose(true);
      GC.SuppressFinalize(this);
    }

    /// <summary>
    /// The import.
    /// </summary>
    /// <param name="data">
    /// The data.
    /// </param>
    public void Import(IEnumerable<EncryptedVoterData> data) {
      int c = 0;
      using (DbTransaction transaction = this._db.Connection.BeginTransaction()) {
        data.ForEach(
          row => {
            this.Add(row);
            c++;
          });
        transaction.Commit();
      }

      if (this.Parent.Logger != null) this.Parent.Logger.Log("Importing data. " + c + " entries.", Level.Info);
    }

    #endregion

    #region Methods

    /// <summary>
    /// Create the voter list database.
    /// </summary>
    /// <param name="fileName">
    /// The name of the file containing the database.
    /// </param>
    /// <param name="password">
    /// The password; if password is null, do not password-protect the DB.
    /// </param>
    private static void InitDb(string fileName, string password) {
      SQLiteConnection.CreateFile(fileName);
      string connString = string.Format("Data Source={0}", fileName);
      if (password != null)
        connString += string.Format(";Password={0}", password);
      using (var db = new SQLiteConnection(connString)) {
        db.Open();
        using (SQLiteCommand cmd = db.CreateCommand()) {
          cmd.CommandText =
            "CREATE TABLE Voters(VoterNumber BLOB NOT NULL PRIMARY KEY DESC, " +
            "CPR BLOB UNIQUE NOT NULL, BallotStatus BLOB NOT NULL)";
          cmd.ExecuteNonQuery();
        }
      }
    }

    /// <summary>
    /// Add this encrypted voter data to the database!
    /// </summary>
    /// <param name="data">
    /// The data to add.
    /// </param>
    private void Add(EncryptedVoterData data) {
      Contract.Requires(!Equals(data, null));

      // Contract.Requires(Contract.ForAll(AllData, row => !row.CPR.Value.IsIdenticalTo(data.CPR.Value) && !row.VoterNumber.Value.IsIdenticalTo(data.VoterNumber.Value)));
      this._db.Voters.AddObject(
        Voter.CreateVoter(data.VoterNumber, data.CPR, data.BallotStatus));
      this._db.SaveChanges();
    }

    /// <summary>
    /// The dispose.
    /// </summary>
    /// <param name="disposing">
    /// The disposing.
    /// </param>
    private void Dispose(bool disposing) {
      this._isDisposed = true;
      if (disposing) this._db.Dispose();
    }

    /// <summary>
    /// The get voter.
    /// </summary>
    /// <param name="cpr">
    /// The cpr.
    /// </param>
    /// <returns>
    /// The <see cref="Voter"/>.
    /// </returns>
    private Voter GetVoter(CPR cpr) {
      CipherText encCpr = this.Parent.Crypto.AsymmetricEncrypt(
        Bytes.From(cpr.Value), this.Parent.Crypto.VoterDataEncryptionKey);

      IQueryable<Voter> res = this._db.Voters.Where(
        data =>
        data.CPR == encCpr.Value);
      return !res.Any() ? null : res.Single();
    }

    /// <summary>
    /// The get voter.
    /// </summary>
    /// <param name="voterNumber">
    /// The voter number.
    /// </param>
    /// <returns>
    /// The <see cref="Voter"/>.
    /// </returns>
    private Voter GetVoter(VoterNumber voterNumber) {
      CipherText encvoterNumber = this.Parent.Crypto.AsymmetricEncrypt(
        Bytes.From(voterNumber.Value), this.Parent.Crypto.VoterDataEncryptionKey);

      IQueryable<Voter> res = this._db.Voters.Where(
        data => data.VoterNumber ==
                encvoterNumber.Value);
      return !res.Any() ? null : res.Single();
    }

    #endregion
  }
}
