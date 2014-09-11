// ***********************************************************************
// Assembly         : Broobu.ManageQso.Service
// Author           : ON8RL
// Created          : 12-07-2013
//
// Last Modified By : ON8RL
// Last Modified On : 12-07-2013
// ***********************************************************************
// <copyright file="ManageQsoService.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.ServiceModel;
using Broobu.HamRadio.Contract.Domain;
using Broobu.ManageQso.Business;
using Broobu.ManageQso.Contract.Interfaces;


namespace Broobu.ManageQso.Service
{
    /// <summary>
    /// Class ManageQsoService.
    /// </summary>
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class ManageQsoSentry : IManageQso
    {
        /// <summary>
        /// Gets the station information.
        /// </summary>
        /// <param name="callId">The call identifier.</param>
        /// <returns>StationViewItem.</returns>
        public StationItem GetStationInfo(string callId)
        {
            return ManageQsoProvider
                .ManageQsos
                .GetStationInfo(callId);
        }

        /// <summary>
        /// Gets the logbook items for station.
        /// </summary>
        /// <param name="callId">The call identifier.</param>
        /// <returns>LogbookItem[][].</returns>
        public LogbookItem[] GetLogbookItemsForStation(string callId)
        {
            return ManageQsoProvider
                .ManageQsos
                .GetLogbookItemsForStation(callId);
        }

        /// <summary>
        /// Saves the logbook items.
        /// </summary>
        /// <param name="items">The items.</param>
        /// <returns>LogbookItem[][].</returns>
        public LogbookItem[] SaveLogbookItems(LogbookItem[] items)
        {
            return ManageQsoProvider
                .ManageQsos
                .SaveLogbookItems(items);
        }

        /// <summary>
        /// Deletes the logbook items.
        /// </summary>
        /// <param name="items">The items.</param>
        /// <returns>LogbookItem[][].</returns>
        public LogbookItem[] DeleteLogbookItems(LogbookItem[] items)
        {
            return ManageQsoProvider
                .ManageQsos
                .DeleteLogbookItems(items);
        }

        /// <summary>
        /// Deletes the logbook item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>LogbookItem.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public LogbookItem DeleteLogbookItem(LogbookItem item)
        {
            return ManageQsoProvider
                .ManageQsos
                .DeleteLogbookItem(item);
        }
    }
}
