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
  using System.Data.Objects;
  using System.Data.Objects.DataClasses;
  using System.Linq;
  using System.Linq.Expressions;
  using System.Reflection;
  using System.Diagnostics.Contracts;

  using Aegis_DVL.Cryptography;
  using Aegis_DVL.Data_Types;
  using Aegis_DVL.Util;

  public static class LinqExtensions {
  [System.Data.Objects.DataClasses.EdmFunction( "VoterModel", "String_Like")]
    public static Boolean Like(this String searchingIn, String lookingFor) {
      throw new Exception("Not implemented");
    }
  }

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
    public IEnumerable<Voter> AllVoters {
      get {
        return
          this._db.Voters.ToArray();
      }
    }

    public IEnumerable<Precinct> AllPrecincts {
      get {
        return
          this._db.Precincts.ToArray();
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
    /// The <see cref="VoterStatus"/>.
    /// </returns>
    /// TODO: review for problems with complexity
    public VoterStatus this[VoterNumber voternumber] {
      get {
        Voter voter = GetVoterByVoterNumber(voternumber);
        if (voter == null) return VoterStatus.Unavailable;
       
        return (VoterStatus) voter.PollbookStatus;
      }

      set {
        if (this.Parent.Logger != null) {
          this.Parent.Logger.Log(
            "Setting status for voter number " +
            voternumber + " to " + value, 
            Level.Info);
        }

        Voter voter = GetVoterByVoterId(voternumber.Value);
        voter.PollbookStatus = (int) value;
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
    /// The <see cref="VoterStatus"/>.
    /// </returns>
    /// TODO: review for problems with complexity
    /*
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
      */
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
    public void Import(IEnumerable<Voter> data) {
      int c = 0;
      using (DbTransaction transaction = this._db.Connection.BeginTransaction()) {
        data.ForEach(
          row => {
            this.Add(row);
            c++;
          });
        transaction.Commit();
      }

      if (this.Parent.Logger != null) this.Parent.Logger.Log("Importing voters. " + c + " entries.", Level.Info);
    }

    public void Import(IEnumerable<Precinct> data) {
      int c = 0;
      using (DbTransaction transaction = this._db.Connection.BeginTransaction()) {
        data.ForEach(
          row => {
            this.Add(row);
            c++;
          });
        transaction.Commit();
      }

      if (this.Parent.Logger != null) this.Parent.Logger.Log("Importing precincts. " + c + " entries.", Level.Info);
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
            "CREATE TABLE Voters(VoterId int not null primary key desc, " +
            "Status nvarchar not null, LastName nvarchar not null, FirstName nvarchar not null, " +
            "MiddleName nvarchar, Suffix nvarchar, DateOfBirth datetime not null, " +
            "EligibleDate datetime not null, MustShowId bit not null, Absentee bit not null, " +
            "ProtectedAddress bit not null, DriversLicense nvarchar, Voted bit not null, ReturnStatus nvarchar, " + 
            "BallotStyle int not null, PrecinctSub nvarchar not null, Address nvarchar not null, " +
            "Municipality nvarchar not null, ZipCode nvarchar not null, StateId int not null, PollbookStatus int not null)";
          cmd.ExecuteNonQuery();
        }
        using (SQLiteCommand cmd = db.CreateCommand()) {
          cmd.CommandText =
            "CREATE TABLE Precincts(PrecinctSplitId nvarchar not null primary key desc, " +
            "LocationName nvarchar not null, Address nvarchar not null, CityStateZip nvarchar not null)";
          cmd.ExecuteNonQuery();
        }

      }
    }

    /// <summary>
    /// Add this voter data to the database!
    /// </summary>
    /// <param name="data">
    /// The data to add.
    /// </param>
    private void Add(Voter data) {
      Contract.Requires(!Equals(data, null));

      // Contract.Requires(Contract.ForAll(AllData, row => !row.CPR.Value.IsIdenticalTo(data.CPR.Value) && !row.VoterNumber.Value.IsIdenticalTo(data.VoterNumber.Value)));
      this._db.Voters.AddObject(data);
      this._db.SaveChanges();
    }

    private void Add(Precinct data) {
      Contract.Requires(!Equals(data, null));
      this._db.Precincts.AddObject(data);
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

    public Precinct GetPrecinctBySplitId(string sid) {
      IQueryable<Precinct> res = this._db.Precincts.Where(data => data.PrecinctSplitId.Equals(sid));
      return !res.Any() ? null : res.Single();
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
    public Voter GetVoterByVoterId(Int32 vid) {
      IQueryable<Voter> res = this._db.Voters.Where(data => data.VoterId == vid);
      return !res.Any() ? null : res.Single();
    }

    public Voter GetVoterByVoterNumber(VoterNumber vn) {
      return GetVoterByVoterId(vn.Value);
    }

    public Voter GetVoterByStateId(Int64 sid) {
      IQueryable<Voter> res = this._db.Voters.Where(data => data.StateId == sid);
      return !res.Any() ? null : res.Single();
    }

    public Voter GetVoterByDLNumber(string dlnumber) {
      dlnumber = dlnumber.ToLower();
      IQueryable <Voter> res = this._db.Voters.Where(
        data => data.DriversLicense.Equals(dlnumber, StringComparison.CurrentCulture));
      return !res.Any() ? null : res.Single();
    }

    public List<Voter> GetVotersBySearchStrings(string lastname, string firstname, string middlename,
                                         string address, string municipality, string zipcode) {
      IQueryable<Voter> res = 
        this._db.Voters.Where(data => data.LastName.Like(lastname + "%") &&
                                      data.FirstName.Like(firstname + "%") &&
                                      data.MiddleName.Like(middlename + "%") &&
                                      data.Address.Like(address + "%") &&
                                      data.Municipality.Like(address + "%") &&
                                      data.ZipCode.Like(address + "%"))
                       .OrderBy(data => data.LastName) 
                       .ThenBy(data => data.FirstName)
                       .ThenBy(data => data.MiddleName);

      Console.WriteLine("Results: " + res.Count());
      return !res.Any() ? null : res.ToList();
    }

    #endregion
  }
}
