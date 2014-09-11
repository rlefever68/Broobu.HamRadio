// ***********************************************************************
// Assembly         : Broobu.Qrz.Adapter
// Author           : ON8RL
// Created          : 12-02-2013
//
// Last Modified By : ON8RL
// Last Modified On : 12-05-2013
// ***********************************************************************
// <copyright file="QrzProxy.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************


using System;
using System.IO;
using System.Net;
using System.Xml;
using System.Xml.Serialization;
using Broobu.Qrz.Contract;
using Broobu.Qrz.Contract.Domain;
using Broobu.Qrz.Contract.Interfaces;
using Iris.Fx.Utils;

namespace Broobu.Qrz.Adapter
{
    /// <summary>
    /// Class QrzProxy.
    /// </summary>
    class QrzProxy : IQrzProxy
    {


        /// <summary>
        /// Does the login.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="passWord">The pass word.</param>
        public Session DoLogin()
        {
            var loginUrl = String.Format(ConfigHelper.QrzLoginCommand,
                ConfigHelper.QrzUrl,
                ConfigHelper.QrzUserName,
                ConfigHelper.QrzPassword);
            QRZDatabase db = CallQrz(loginUrl);
            return db.Session;
        }



        /// <summary>
        /// Gets the call sign.
        /// </summary>
        /// <param name="callSign">The call sign.</param>
        /// <returns>QRZDatabase.</returns>
        public CallSign GetCallSign(string callSign)
        {
            string session = DoLogin().Key;
            var loginUrl = String.Format(ConfigHelper.QrzGetCallSignCommand,
                ConfigHelper.QrzUrl,
                session, 
                callSign);
            QRZDatabase db = CallQrz(loginUrl);
            return db.Callsign;
        }


        /// <summary>
        /// Calls the QRZ.
        /// </summary>
        /// <param name="url">The URL.</param>
        private QRZDatabase CallQrz(string url, bool isDebug = false)
        {
            var wc = new WebClient();
            var sIn = wc.OpenRead(url);
            if (sIn == null) return null;
            if (isDebug)
            {
                string s = sIn.AsString();
                Console.WriteLine(s);
                sIn.Position = 0;
            }
            var sr = new StreamReader(sIn);
            var ser = new XmlSerializer(typeof(QRZDatabase));
            return (QRZDatabase)ser.Deserialize(sr);
        }

    }
}
