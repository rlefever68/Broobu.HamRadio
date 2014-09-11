// ***********************************************************************
// Assembly         : Broobu.ManageQso.Contract
// Author           : ON8RL
// Created          : 12-07-2013
//
// Last Modified By : ON8RL
// Last Modified On : 12-07-2013
// ***********************************************************************
// <copyright file="ManageQsoAgent.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using Broobu.HamRadio.Contract.Domain;
using Broobu.ManageQso.Contract.Interfaces;
using Iris.Fx.Networking.Wcf;

namespace Broobu.ManageQso.Contract.Agent
{
    /// <summary>
    /// Class ManageQsoAgent.
    /// </summary>
    class ManageQsoAgent : DiscoProxy<IManageQso>, IManageQsoAgent
    {
        /// <summary>
        /// Gets the contract namespace.
        /// </summary>
        /// <returns>System.String.</returns>
        protected override string GetContractNamespace()
        {
            return ManageQsoConst.ServiceNamespace;
        }


        /// <summary>
        /// Gets the station information.
        /// </summary>
        /// <param name="callId">The call identifier.</param>
        /// <returns>StationViewItem.</returns>
        public StationItem GetStationInfo(string callId)
        {
            var clt = CreateClient();
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
        /// Gets the logbook items for station.
        /// </summary>
        /// <param name="callId">The call identifier.</param>
        /// <returns>LogbookItem[][].</returns>
        public LogbookItem[] GetLogbookItemsForStation(string callId)
        {
            var clt = CreateClient();
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
        /// Saves the logbook items.
        /// </summary>
        /// <param name="items">The items.</param>
        /// <returns>LogbookItem[][].</returns>
        public LogbookItem[] SaveLogbookItems(LogbookItem[] items)
        {
            var clt = CreateClient();
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
        /// Deletes the logbook items.
        /// </summary>
        /// <param name="items">The items.</param>
        /// <returns>LogbookItem[][].</returns>
        public LogbookItem[] DeleteLogbookItems(LogbookItem[] items)
        {
            var clt = CreateClient();
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
        /// Deletes the logbook item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>LogbookItem.</returns>
        public LogbookItem DeleteLogbookItem(LogbookItem item)
        {
            var clt = CreateClient();
            try
            {
                return clt.DeleteLogbookItem(item);
            }
            finally
            {
                CloseClient(clt);
            }            
        }
    }
}
