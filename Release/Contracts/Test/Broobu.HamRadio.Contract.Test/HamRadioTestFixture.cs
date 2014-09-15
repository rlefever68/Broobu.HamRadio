// ***********************************************************************
// Assembly         : Broobu.HamRadio.Contract.Test
// Author           : ON8RL
// Created          : 12-05-2013
//
// Last Modified By : ON8RL
// Last Modified On : 12-07-2013
// ***********************************************************************
// <copyright file="HamRadioTestFixture.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using Broobu.HamRadio.Business;
using Broobu.HamRadio.Contract.Domain;
using Broobu.HamRadio.Contract.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Broobu.HamRadio.Contract.Test
{
    /// <summary>
    ///     Class HamRadioTestFixture.
    /// </summary>
    [TestClass]
    public class HamRadioTestFixture : IHamRadio
    {
        /// <summary>
        ///     Gets the station information.
        /// </summary>
        /// <param name="callId">The call identifier.</param>
        /// <returns>StationItem.</returns>
        public StationItem GetStationInfo(string callId)
        {
            //return HamRadioPortal
            //    .Agent
            //    .GetStationInfo(callId);
            return HamRadioProvider
                .HamRadio
                .GetStationInfo(callId);
        }

        /// <summary>
        ///     Gets the logbook items for station.
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
        ///     Saves the logbook items.
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
        ///     Deletes the logbook items.
        /// </summary>
        /// <param name="items">The items.</param>
        /// <returns>LogbookItem[][].</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public LogbookItem[] DeleteLogbookItems(LogbookItem[] items)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Deletes the logbook item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>LogbookItem.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public LogbookItem DeleteLogbookItem(LogbookItem item)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Try_s the get station information.
        /// </summary>
        [TestMethod]
        public void Try_GetStationInfo()
        {
            //var res = GetStationInfo("ON4NL");
            //Assert.IsNotNull(res);
            //PrintInfo(res);

            //res = GetStationInfo("ON8RL");
            //Assert.IsNotNull(res);
            //PrintInfo(res);


            //res = GetStationInfo("ON3NL");
            //Assert.IsNotNull(res);
            //PrintInfo(res);


            //res = GetStationInfo("A61BK");
            //Assert.IsNotNull(res);
            //PrintInfo(res);


            StationItem res = GetStationInfo("ON3rl");
            Assert.IsNotNull(res);
            PrintInfo(res);
        }


        private void PrintInfo(StationItem res)
        {
            Console.WriteLine("");
            Console.WriteLine("Hello, {0} {1}", res.FirstName, res.LastName);
            Console.WriteLine("\t@Long: {0,8}\tLat: {1,8}", res.Longitude, res.Latitude);
        }


        /// <summary>
        ///     Try_s the register test objects.
        /// </summary>
        [TestMethod]
        public void Try_RegisterTestObjects()
        {
            LogbookItem[] res = RegisterTestObjects();
            Assert.IsNotNull(res);
        }


        /// <summary>
        ///     Try_s the get logbook items for station.
        /// </summary>
        [TestMethod]
        public void Try_GetLogbookItemsForStation()
        {
            LogbookItem[] res = GetLogbookItemsForStation("ON8RL");
            Assert.IsNotNull(res);
            foreach (LogbookItem logbookItem in res)
            {
                Console.WriteLine("{0} worked {1} \t Started at:{3} RX: {2}", logbookItem.MyCallId,
                    logbookItem.WorkedStationId,
                    logbookItem.RxReport,
                    logbookItem.Started);
            }
        }

        /// <summary>
        ///     Registers the test objects.
        /// </summary>
        /// <returns>LogbookItem[][].</returns>
        public LogbookItem[] RegisterTestObjects()
        {
            LogbookItem[] res = HamRadioDomainGenerator.GetTestObjects();
            return SaveLogbookItems(res);
        }

        /// <summary>
        ///     Registers the required objects.
        /// </summary>
        /// <exception cref="System.NotImplementedException"></exception>
        public void RegisterRequiredObjects()
        {
            throw new NotImplementedException();
        }
    }
}