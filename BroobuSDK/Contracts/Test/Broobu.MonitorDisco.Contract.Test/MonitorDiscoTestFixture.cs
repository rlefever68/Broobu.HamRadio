// ***********************************************************************
// Assembly         : Broobu.MonitorDisco.Contract.Test
// Author           : ON8RL
// Created          : 12-04-2013
//
// Last Modified By : ON8RL
// Last Modified On : 12-04-2013
// ***********************************************************************
// <copyright file="MonitorDiscoTestFixture.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using Broobu.MonitorDisco.Contract.Agent;
using Broobu.MonitorDisco.Contract.Domain;
using Broobu.MonitorDisco.Contract.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Broobu.MonitorDisco.Contract.Test
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class MonitorDiscoTestFixture : IMonitorDisco
    {

        /// <summary>
        /// Tries the get all endpoints.
        /// </summary>
        [TestMethod]
        public void Try_GetAllEndpoints()
        {
            var res = GetAllEndpoints();
            Console.WriteLine("Contract\tEndpoint");
            Console.WriteLine("----------------------------");
            foreach (var discoInfo in res)
            {
                Console.WriteLine("{0}\t{1}",discoInfo.Contract, discoInfo.Endpoint);
            }
            Assert.IsNotNull(res);
        }



        /// <summary>
        /// Gets all endpoints.
        /// </summary>
        /// <returns>DiscoViewItem[][].</returns>
        public DiscoInfo[] GetAllEndpoints()
        {
            return MonitorDiscoPortal
                .Agent
                .GetAllEndpoints();
        }
    }
}
