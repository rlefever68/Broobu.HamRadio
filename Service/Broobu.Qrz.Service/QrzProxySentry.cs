// ***********************************************************************
// Assembly         : Broobu.Qrz.Service
// Author           : ON8RL
// Created          : 12-05-2013
//
// Last Modified By : ON8RL
// Last Modified On : 12-05-2013
// ***********************************************************************
// <copyright file="QrzProxyService.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.ServiceModel;
using Broobu.Qrz.Adapter;
using Broobu.Qrz.Contract.Domain;
using Broobu.Qrz.Contract.Interfaces;
using Iris.Fx.Networking.Wcf;

namespace Broobu.Qrz.Service
{

    /// <summary>
    /// Class QrzProxyService.
    /// </summary>
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class QrzProxySentry : IQrzProxy
    {

        /// <summary>
        /// Does the login.
        /// </summary>
        /// <returns>QRZDatabase.</returns>
        public Session DoLogin()
        {
            return QrzDotCom
                .Proxy
                .DoLogin();
        }

        /// <summary>
        /// Gets the call sign.
        /// </summary>
        /// <param name="callSign">The call sign.</param>
        /// <returns>QRZDatabase.</returns>
        public CallSign GetCallSign(string callSign)
        {
            return QrzDotCom
                .Proxy
                .GetCallSign(callSign);
        }
    }
}
