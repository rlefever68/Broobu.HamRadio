﻿// ***********************************************************************
// Assembly         : Iris.Disco.Contract.Test
// Author           : ON8RL
// Created          : 12-04-2013
//
// Last Modified By : ON8RL
// Last Modified On : 12-04-2013
// ***********************************************************************
// <copyright file="DiscoTestFixture.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using Iris.Fx.Agent;
using Iris.Fx.Domain;
using Iris.Fx.Exceptions;
using Iris.Fx.Interfaces;
using Iris.Fx.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Broobu.Disco.Contract.Test
{
    /// <summary>
    /// Class DiscoTestFixture.
    /// </summary>
    [TestClass]
    public class DiscoTestFixture : IDisco
    {


        [TestMethod]
        public void Try_RegisterCloudContract()
        {
            try
            {
                var n = new CloudContract() { Id = "TestCloudContract", Publisher = "me" };
                var res = DiscoPortal
                    .CloudContracts
                    .SaveCloudContract(n);
                Console.WriteLine("Saved CloudContract [{0}]", res.Id);
                FxLog<DiscoTestFixture>.DebugFormat("Saved CloudContract [{0}]", res.Id);
            }
            catch (Exception exception)
            {
                FxLog<DiscoTestFixture>.ErrorFormat(exception.GetCombinedMessages());
                Assert.Fail(exception.Message);
            }
        }



        /// <summary>
        /// Try_s the get all endpoints.
        /// </summary>
        [TestMethod]
        public void Try_GetAllEndpoints()
        {
            var res = GetAllEndpoints();
            Assert.IsNotNull(res);
            foreach (var serializableEndpoint in res)
            {
                Console.WriteLine(String.Format("Contract: {0}",serializableEndpoint.ContractName));
            }
        }

        /// <summary>
        /// Gets the endpoints.
        /// </summary>
        /// <param name="contractType">Type of the contract.</param>
        /// <returns>SerializableEndpoint[][].</returns>
        public SerializableEndpoint[] GetEndpoints(string contractType)
        {
            return DiscoPortal
                .Disco
                .GetAllEndpoints();

        }

        /// <summary>
        /// Gets all endpoints.
        /// </summary>
        /// <returns>SerializableEndpoint[][].</returns>
        public SerializableEndpoint[] GetAllEndpoints()
        {
            return DiscoPortal
                .Disco
                .GetAllEndpoints();
        }

        /// <summary>
        /// Gets all endpoint addresses.
        /// </summary>
        /// <returns>DiscoItem[][].</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public DiscoItem[] GetAllEndpointAddresses()
        {
            throw new NotImplementedException();
        }


        public CloudContract GetCloudContract(string contractId)
        {
            throw new NotImplementedException();
        }

        public CloudContract SaveCloudContract(CloudContract contract)
        {
            throw new NotImplementedException();
        }

        public CloudContract[] SaveCloudContracts(CloudContract[] contract)
        {
            throw new NotImplementedException();
        }
    }
}
