﻿using System;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Net;

namespace Aegis_DVL.Commands
{
    [Serializable]
    public class AllStationsAvailable : ICommand
    {

        /// <summary>
        /// This station is available!
        /// </summary>
        /// <param name="sender">The address of the one sending the command.</param>
        public AllStationsAvailable(IPEndPoint sender)
        {
            Contract.Requires(sender != null);
            Sender = sender;
        }

        public IPEndPoint Sender { get; private set; }

        public void Execute(Station receiver)
        {
            if (receiver.Manager.Equals(Sender)) return;
            receiver.AllStationsAvailable = true;
        }
    }
}