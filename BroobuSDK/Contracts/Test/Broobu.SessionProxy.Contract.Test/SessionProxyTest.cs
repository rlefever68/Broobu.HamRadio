// ***********************************************************************
// Assembly         : Iris.SessionProxy.Contract.Test
// Author           : ON8RL
// Created          : 12-04-2013
//
// Last Modified By : ON8RL
// Last Modified On : 12-04-2013
// ***********************************************************************
// <copyright file="SessionProxyTest.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using Broobu.SessionProxy.Contract.Agent;
using Broobu.SessionProxy.Contract.Interfaces;
using Iris.Fx.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Broobu.SessionProxy.Contract.Test
{
    /// <summary>
    /// Class SessionProxyTest.
    /// </summary>
    [TestClass]
    public class SessionProxyTest : ISessionProxy, IQuerySession
    {
        /// <summary>
        /// Try_s the get sessions.
        /// </summary>
        [TestMethod]
        public void Try_GetSessions()
        {
            var res = GetSessions();
            foreach (var irisSession in res)
            {
                Console.WriteLine(String.Format("Name : {0}", irisSession.Username));
            }
        }

        /// <summary>
        /// Starts the session.
        /// </summary>
        /// <param name="session">The session.</param>
        /// <returns>IrisSession.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public IrisSession StartSession(IrisSession session)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Gets the sessions.
        /// </summary>
        /// <returns>IrisSession[][].</returns>
        public IrisSession[] GetSessions()
        {
            return SessionProxyPortal
                .QuerySession
                .GetSessions();
        }

        /// <summary>
        /// Ends the session.
        /// </summary>
        /// <param name="session">The session.</param>
        /// <returns>IrisSession.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public IrisSession EndSession(IrisSession session)
        {
            return SessionProxyPortal
                .SessionProxy
                .EndSession(session);
        }

    }
}
