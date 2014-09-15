// ***********************************************************************
// Assembly         : Broobu.HamRadio.Service
// Author           : ON8RL
// Created          : 12-05-2013
//
// Last Modified By : ON8RL
// Last Modified On : 12-07-2013
// ***********************************************************************
// <copyright file="HamRadioService.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.ServiceModel;
using Broobu.HamRadio.Business;
using Broobu.HamRadio.Contract.Domain;
using Broobu.HamRadio.Contract.Interfaces;
using Wulka.Networking.Wcf;

namespace Broobu.HamRadio.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    /// <summary>
    ///     Class HamRadioService.
    /// </summary>
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class HamRadioSentry : SentryBase, IHamRadio
    {
        /// <summary>
        ///     Gets the station information.
        /// </summary>
        /// <param name="callId">The call identifier.</param>
        /// <returns>StationItem.</returns>
        public StationItem GetStationInfo(string callId)
        {
            return HamRadioProvider
                .HamRadio
                .GetStationInfo(callId);
        }

        /// <summary>
        ///     Gets the logbook items for station.
        /// </summary>
        /// <param name="callId">The call identifier.</param>
        /// <returns>LogbookItem[][].</returns>
        public LogbookItem[] GetLogbookItemsForStation(string callId)
        {
            return HamRadioProvider
                .HamRadio
                .GetLogbookItemsForStation(callId);
        }

        /// <summary>
        ///     Saves the logbook items.
        /// </summary>
        /// <param name="items">The items.</param>
        /// <returns>LogbookItem[][].</returns>
        public LogbookItem[] SaveLogbookItems(LogbookItem[] items)
        {
            return HamRadioProvider
                .HamRadio
                .SaveLogbookItems(items);
        }

        /// <summary>
        ///     Deletes the logbook items.
        /// </summary>
        /// <param name="items">The items.</param>
        /// <returns>LogbookItem[][].</returns>
        public LogbookItem[] DeleteLogbookItems(LogbookItem[] items)
        {
            return HamRadioProvider
                .HamRadio
                .DeleteLogbookItems(items);
        }

        /// <summary>
        ///     Deletes the logbook item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>LogbookItem.</returns>
        public LogbookItem DeleteLogbookItem(LogbookItem item)
        {
            return HamRadioProvider
                .HamRadio
                .DeleteLogbookItem(item);
        }

        /// <summary>
        ///     Registers the required domain objects.
        /// </summary>
        protected override void RegisterRequiredDomainObjects()
        {
            HamRadioProvider
                .HamRadio
                .InflateDomain();
        }
    }
}