﻿#region Copyright and License

// // -----------------------------------------------------------------------
// // <copyright file="PublicKeyExchangeCommand.cs" company="DemTech">
// // Copyright (C) 2013 Joseph Kiniry, DemTech, 
// // IT University of Copenhagen, Technical University of Denmark,
// // Nikolaj Aaes, Nicolai Skovvart
// // </copyright>
// // -----------------------------------------------------------------------
#endregion

namespace Aegis_DVL.Commands {
  using System;
  using System.Diagnostics.Contracts;
  using System.IO;
  using System.Net;
  using System.Threading.Tasks;

  using Aegis_DVL.Cryptography;
  using Aegis_DVL.Data_Types;

  using Org.BouncyCastle.Asn1;

  /// <summary>
  /// The public key exchange command.
  /// </summary>
  [Serializable] public class PublicKeyExchangeCommand : ICommand {
    #region Fields

    /// <summary>
    /// The _is reply.
    /// </summary>
    private readonly bool _isReply;

    /// <summary>
    /// The _wrapper.
    /// </summary>
    private readonly PublicKeyWrapper _wrapper;

    #endregion

    #region Constructors and Destructors

    /// <summary>
    /// Initializes a new instance of the <see cref="PublicKeyExchangeCommand"/> class. 
    /// May I have a new command that exchanges public keys with the target?
    /// </summary>
    /// <param name="parent">
    /// The parent station starting the exchange. Should be a manager.
    /// </param>
    /// <param name="isReply">
    /// Whether it's a reply from the target. Shouldn't be set manually. Set to false as default.
    /// </param>
    public PublicKeyExchangeCommand(Station parent, bool isReply = false) {
      Contract.Requires(parent != null);
      this._isReply = isReply;
      this.Sender = parent.Address;
      var pswd = Crypto.GeneratePassword();
      if (isReply) parent.UI.ShowPasswordOnStation(pswd);
      else parent.UI.ShowPasswordOnManager(pswd);
      this._wrapper = new PublicKeyWrapper(parent.Crypto, pswd);
    }

    #endregion

    #region Public Properties

    /// <summary>
    /// Gets the sender.
    /// </summary>
    public IPEndPoint Sender { get; private set; }

    #endregion

    #region Public Methods and Operators

    /// <summary>
    /// The execute.
    /// </summary>
    /// <param name="receiver">
    /// The receiver.
    /// </param>
    public void Execute(Station receiver) {
      // Don't perform key exchange when we have a manager
      // if (!_isReply && receiver.Manager != null)
      // receiver.ShutDownElection();
      try {
        this.GetPassword(receiver);
      } catch (TaskCanceledException) {
        return;
      }

      if (this._isReply) {
        // Done with key-exchange, synchronize new peer
        receiver.Communicator.Send(new SyncCommand(receiver), this.Sender);
        receiver.AnnounceAddPeer(this.Sender, receiver.Peers[this.Sender]);
        if (receiver.ElectionInProgress) {
          /*
                    while (!receiver.AllStationsAvailable)
                    {
                        /*Wait for the station to be ready
                    }
                    */
          receiver.Communicator.Send(new StartElectionCommand(receiver.Address), this.Sender);
        }

        return;
      }

      receiver.Manager = this.Sender;

      // Respond with own public key
      var reply = new PublicKeyExchangeCommand(receiver, true);
      receiver.Communicator.Send(reply, this.Sender);
    }

    /// <summary>
    /// The get password.
    /// </summary>
    /// <param name="receiver">
    /// The receiver.
    /// </param>
    /// <exception cref="TaskCanceledException">
    /// </exception>
    public void GetPassword(Station receiver) {
      var deObfuscationPassword = this._isReply
                                    ? receiver.UI.StationExchangingKey(this.Sender)
                                    : receiver.UI.ManagerExchangingKey(this.Sender);
      try {
        if (deObfuscationPassword == string.Empty) throw new TaskCanceledException();
        var key = this._wrapper.GetKey(receiver.Crypto, deObfuscationPassword);
        receiver.AddPeer(this.Sender, key);
      } catch (Exception e) {
        if (e is ArgumentException ||
            e is IOException ||
            e is Asn1ParsingException) this.GetPassword(receiver);
        else throw;
      }
    }

    #endregion
  }
}
