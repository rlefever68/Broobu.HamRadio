// ***********************************************************************
// Assembly         : Broobu.Qrz.Contract
// Author           : ON8RL
// Created          : 12-05-2013
//
// Last Modified By : ON8RL
// Last Modified On : 12-05-2013
// ***********************************************************************
// <copyright file="QrzProxyAgent.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Broobu.Qrz.Contract.Domain;
using Broobu.Qrz.Contract.Interfaces;
using Iris.Fx.Networking.Wcf;

namespace Broobu.Qrz.Contract.Agent
{
    /// <summary>
    /// Class QrzProxyAgent.
    /// </summary>
    class QrzProxyAgent : DiscoProxy<IQrzProxy>, IQrzProxyAgent
    {
        /// <summary>
        /// Does the login.
        /// </summary>
        /// <returns>QRZDatabase.</returns>
        public Session DoLogin()
        {
            var clt = CreateClient();
            try
            {
                return clt.DoLogin();
            }
            finally
            {
                CloseClient(clt);
            }
        }

        /// <summary>
        /// Gets the call sign.
        /// </summary>
        /// <param name="callSign">The call sign.</param>
        /// <returns>QRZDatabase.</returns>
        public CallSign GetCallSign(string callSign)
        {
            var clt = CreateClient();
            try
            {
                return clt.GetCallSign(callSign);
            }
            finally
            {
                CloseClient(clt);
            }
        }


        /// <summary>
        /// Gets the contract namespace.
        /// </summary>
        /// <returns>System.String.</returns>
        protected override string GetContractNamespace()
        {
            return QrzConst.ServiceNamespace;
        }
    }
}