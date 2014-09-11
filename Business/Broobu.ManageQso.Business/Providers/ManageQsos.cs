// ***********************************************************************
// Assembly         : Broobu.ManageQso.Business
// Author           : ON8RL
// Created          : 12-07-2013
//
// Last Modified By : ON8RL
// Last Modified On : 12-07-2013
// ***********************************************************************
// <copyright file="ManageQsoProvider.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using Broobu.HamRadio.Contract;
using Broobu.HamRadio.Contract.Domain;
using Broobu.ManageQso.Business.Interfaces;


namespace Broobu.ManageQso.Business.Providers
{
    /// <summary>
    /// Class ManageQsoProvider.
    /// </summary>
    class ManageQsos : IManageQsos
    {
        /// <summary>
        /// Gets the station information.
        /// </summary>
        /// <param name="callId">The call identifier.</param>
        /// <returns>StationViewItem.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public StationItem GetStationInfo(string callId)
        {
            return HamRadioPortal
                .Agent
                .GetStationInfo(callId);
            
        }

        /// <summary>
        /// Gets the logbook items for station.
        /// </summary>
        /// <param name="callId">The call identifier.</param>
        /// <returns>LogbookItem[][].</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public LogbookItem[] GetLogbookItemsForStation(string callId)
        {
            return HamRadioPortal
                .Agent
                .GetLogbookItemsForStation(callId);
        }

        /// <summary>
        /// Saves the logbook items.
        /// </summary>
        /// <param name="items">The items.</param>
        /// <returns>LogbookItem[][].</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public LogbookItem[] SaveLogbookItems(LogbookItem[] items)
        {
            return HamRadioPortal
                .Agent
                .SaveLogbookItems(items);
        }

        /// <summary>
        /// Deletes the logbook items.
        /// </summary>
        /// <param name="items">The items.</param>
        /// <returns>LogbookItem[][].</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public LogbookItem[] DeleteLogbookItems(LogbookItem[] items)
        {
            return HamRadioPortal
                .Agent
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
            return HamRadioPortal
                .Agent
                .DeleteLogbookItem(item);
        }
    }
}