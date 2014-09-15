// ***********************************************************************
// Assembly         : Broobu.HamRadio.Contract
// Author           : ON8RL
// Created          : 12-05-2013
//
// Last Modified By : ON8RL
// Last Modified On : 12-07-2013
// ***********************************************************************
// <copyright file="HamRadioAgent.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using Broobu.HamRadio.Contract.Domain;
using Broobu.HamRadio.Contract.Interfaces;
using Wulka.Networking.Wcf;

namespace Broobu.HamRadio.Contract.Agent
{
    /// <summary>
    ///     Class HamRadioAgent.
    /// </summary>
    internal class HamRadioAgent : DiscoProxy<IHamRadio>, IHamRadioAgent
    {
        /// <summary>
        ///     Gets the station information.
        /// </summary>
        /// <param name="callId">The call identifier.</param>
        /// <returns>StationItem.</returns>
        public StationItem GetStationInfo(string callId)
        {
            IHamRadio clt = CreateClient();
            try
            {
                return clt.GetStationInfo(callId);
            }
            finally
            {
                CloseClient(clt);
            }
        }

        /// <summary>
        ///     Gets the logbook items for station.
        /// </summary>
        /// <param name="callId">The call identifier.</param>
        /// <returns>LogbookItem[][].</returns>
        public LogbookItem[] GetLogbookItemsForStation(string callId)
        {
            IHamRadio clt = CreateClient();
            try
            {
                return clt.GetLogbookItemsForStation(callId);
            }
            finally
            {
                CloseClient(clt);
            }
        }

        /// <summary>
        ///     Saves the logbook items.
        /// </summary>
        /// <param name="items">The items.</param>
        /// <returns>LogbookItem[][].</returns>
        public LogbookItem[] SaveLogbookItems(LogbookItem[] items)
        {
            IHamRadio clt = CreateClient();
            try
            {
                return clt.SaveLogbookItems(items);
            }
            finally
            {
                CloseClient(clt);
            }
        }

        /// <summary>
        ///     Deletes the logbook items.
        /// </summary>
        /// <param name="items">The items.</param>
        /// <returns>LogbookItem[][].</returns>
        public LogbookItem[] DeleteLogbookItems(LogbookItem[] items)
        {
            IHamRadio clt = CreateClient();
            try
            {
                return clt.DeleteLogbookItems(items);
            }
            finally
            {
                CloseClient(clt);
            }
        }

        /// <summary>
        ///     Deletes the logbook item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>LogbookItem.</returns>
        public LogbookItem DeleteLogbookItem(LogbookItem item)
        {
            IHamRadio clt = CreateClient();
            try
            {
                return clt.DeleteLogbookItem(item);
            }
            finally
            {
                CloseClient(clt);
            }
        }

        /// <summary>
        ///     Gets the contract namespace.
        /// </summary>
        /// <returns>System.String.</returns>
        protected override string GetContractNamespace()
        {
            return HamRadioConst.ServiceNamespace;
        }
    }
}