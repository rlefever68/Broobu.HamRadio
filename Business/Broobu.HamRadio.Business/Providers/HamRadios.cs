// ***********************************************************************
// Assembly         : Broobu.HamRadio.Business
// Author           : Rafael Lefever
// Created          : 01-15-2014
//
// Last Modified By : Rafael Lefever
// Last Modified On : 01-19-2014
// ***********************************************************************
// <copyright file="HamRadios.cs" company="Broobu Systems Ltd.">
//     Copyright (c) Broobu Systems Ltd.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using Broobu.HamRadio.Business.Interfaces;
using Broobu.HamRadio.Contract.Domain;
using Broobu.Qrz.Contract;
using Iris.Fx.Data;
using Iris.Fx.Logging;
using Iris.Fx.Utils;
using log4net;



namespace Broobu.HamRadio.Business.Providers
{
    /// <summary>
    /// Class HamRadioProvider.
    /// </summary>
    class HamRadios : IHamRadioProvider
    {



        /// <summary>
        /// The logger
        /// </summary>
        ILog logger = LogManager.GetLogger(typeof(HamRadios));


        /// <summary>
        /// Gets the station information.
        /// </summary>
        /// <param name="callId">The call identifier.</param>
        /// <returns>StationItem.</returns>
        public StationItem GetStationInfo(string callId)
        {
            try
            {
                callId = callId.ToUpper();
                StationItem si = null;
                logger.DebugFormat("Saving {0}.", callId);
                var res = QrzDotComPortal
                    .Proxy
                    .GetCallSign(callId);
                si = res != null ? res.ToStationItem() : CreateUnknownStationItem(callId);
                return Provider<StationItem>.Save(si);
            }
            catch (Exception exception)
            {
                logger.LogException(exception);
                return null;
            }
        }

        /// <summary>
        /// Creates the unknown station item.
        /// </summary>
        /// <param name="callId">The call identifier.</param>
        /// <returns>StationItem.</returns>
        private StationItem CreateUnknownStationItem(string callId)
        {
            return new StationItem() {Id=callId, CallId = callId, User = callId, SessionId = "UNKNOWN"};
        }

        /// <summary>
        /// Gets the logbook items for station.
        /// </summary>
        /// <param name="callId">The call identifier.</param>
        /// <returns>LogbookItem[][].</returns>
        public LogbookItem[] GetLogbookItemsForStation(string callId)
        {
            return Provider<LogbookItem>.Where("MyCallId",callId);
        }

        /// <summary>
        /// Saves the logbook items.
        /// </summary>
        /// <param name="items">The items.</param>
        /// <returns>LogbookItem[][].</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public LogbookItem[] SaveLogbookItems(LogbookItem[] items)
        {
            return Provider<LogbookItem>.Save(items);
        }

        /// <summary>
        /// Deletes the logbook items.
        /// </summary>
        /// <param name="items">The items.</param>
        /// <returns>LogbookItem[][].</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public LogbookItem[] DeleteLogbookItems(LogbookItem[] items)
        {
            return Provider<LogbookItem>.Delete(items);
        }

        /// <summary>
        /// Deletes the logbook item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>LogbookItem.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public LogbookItem DeleteLogbookItem(LogbookItem item)
        {
            return Provider<LogbookItem>.Delete(item);
        }

        /// <summary>
        /// Registers the required objects.
        /// </summary>
        /// <exception cref="System.NotImplementedException"></exception>
        public void InflateDomain()
        {
        }
    }
}