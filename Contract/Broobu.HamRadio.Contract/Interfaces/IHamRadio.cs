// ***********************************************************************
// Assembly         : Broobu.HamRadio.Contract
// Author           : ON8RL
// Created          : 12-05-2013
//
// Last Modified By : ON8RL
// Last Modified On : 12-07-2013
// ***********************************************************************
// <copyright file="IHamRadio.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.ServiceModel;
using Broobu.HamRadio.Contract.Domain;
using Iris.Fx.Domain;

namespace Broobu.HamRadio.Contract.Interfaces
{


    /// <summary>
    /// Class HamRadioConst.
    /// </summary>
    public static class HamRadioConst
    {
        /// <summary>
        /// The service namespace
        /// </summary>
        public const string ServiceNamespace = "http://hamradio.broobu.com/13/01";
    }


    /// <summary>
    /// Interface IHamRadio
    /// </summary>
    [ServiceKnownType(typeof(Result))]
    [ServiceKnownType(typeof(DomainObject<LogbookItem>))]
    [ServiceKnownType(typeof(DomainObject<StationItem>))]
    [ServiceContract(Namespace = HamRadioConst.ServiceNamespace)]
    public interface IHamRadio
    {
        /// <summary>
        /// Gets the station information.
        /// </summary>
        /// <param name="callId">The call identifier.</param>
        /// <returns>StationItem.</returns>
        [OperationContract]
        StationItem GetStationInfo(string callId);
        /// <summary>
        /// Gets the logbook items for station.
        /// </summary>
        /// <param name="callId">The call identifier.</param>
        /// <returns>LogbookItem[][].</returns>
        [OperationContract]
        LogbookItem[] GetLogbookItemsForStation(string callId);
        /// <summary>
        /// Saves the logbook items.
        /// </summary>
        /// <param name="items">The items.</param>
        /// <returns>LogbookItem[][].</returns>
        [OperationContract]
        LogbookItem[] SaveLogbookItems(LogbookItem[] items);
        /// <summary>
        /// Deletes the logbook items.
        /// </summary>
        /// <param name="items">The items.</param>
        /// <returns>LogbookItem[][].</returns>
        [OperationContract]
        LogbookItem[] DeleteLogbookItems(LogbookItem[] items);
        /// <summary>
        /// Deletes the logbook item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>LogbookItem.</returns>
        [OperationContract]
        LogbookItem DeleteLogbookItem(LogbookItem item);

    }
}