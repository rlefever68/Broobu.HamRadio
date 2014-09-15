// ***********************************************************************
// Assembly         : Broobu.Qrz.Contract.Test
// Author           : ON8RL
// Created          : 12-05-2013
//
// Last Modified By : ON8RL
// Last Modified On : 12-05-2013
// ***********************************************************************
// <copyright file="QrzTestFixture.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using Broobu.Qrz.Adapter;
using Broobu.Qrz.Contract.Domain;
using Broobu.Qrz.Contract.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Broobu.Qrz.Contract.Test
{
    /// <summary>
    ///     Class QrzTestFixture.
    /// </summary>
    [TestClass]
    public class QrzTestFixture : IQrzProxy
    {
        /// <summary>
        ///     Does the login.
        /// </summary>
        /// <returns>Session.</returns>
        public Session DoLogin()
        {
            try
            {
                Session sess = QrzDotCom
                    .Proxy
                    .DoLogin();
                //var sess = QrzDotComPortal
                //    .Proxy
                //    .DoLogin();
                return sess;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        ///     Gets the call sign.
        /// </summary>
        /// <param name="callSign">The call sign.</param>
        /// <returns>CallSign.</returns>
        public CallSign GetCallSign(string callSign)
        {
            try
            {
                CallSign res = QrzDotCom
                    .Proxy
                    .GetCallSign(callSign);
                //var res = QrzDotComPortal
                //    .Proxy
                //    .GetCallSign(callSign);
                if (res != null)
                    Console.WriteLine(res.call);
                return res;
            }
            catch (Exception exception)
            {
                Assert.Fail(exception.Message);
            }
            return null;
        }

        /// <summary>
        ///     Try_s the do login.
        /// </summary>
        [TestMethod]
        public void Try_DoLogin()
        {
            Session res = DoLogin();
            Console.WriteLine("Qrz Login Succeeded session: {0}", res.Key);
            Assert.IsNotNull(res);
        }


        /// <summary>
        ///     Try_s the get call sign.
        /// </summary>
        [TestMethod]
        public void Try_GetCallSign()
        {
            CallSign res = GetCallSign("ON8RL");
            Console.WriteLine("Info for ON8RL: {0}", res.user);
            Assert.IsNotNull(res);
        }


        [TestMethod]
        public void Try_GetInvalidCallSign()
        {
            CallSign res = GetCallSign("XXXXX");
            Assert.IsNull(res);
        }
    }
}