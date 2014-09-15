// ***********************************************************************
// Assembly         : Broobu.Hamdroid.Contract
// Author           : Rafael Lefever
// Created          : 01-19-2014
//
// Last Modified By : Rafael Lefever
// Last Modified On : 01-19-2014
// ***********************************************************************
// <copyright file="HamdroidAgent.cs" company="Broobu Systems Ltd.">
//     Copyright (c) Broobu Systems Ltd.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.IO;
using System.Net;
using Broobu.Hamdroid.Contract.Domain;
using Broobu.Hamdroid.Contract.Interfaces;
using Wulka.Utils;

namespace Broobu.Hamdroid.Contract.Agents
{
    /// <summary>
    ///     Class HamdroidAgent.
    /// </summary>
    internal class HamdroidAgent : IHamdroidAgent
    {
        /// <summary>
        ///     Gets the call sign information.
        /// </summary>
        /// <param name="callsingId">The callsing identifier.</param>
        /// <param name="clientLat">The Latitude coordinate of the client</param>
        /// <param name="clientLon">The Longitude coordinate of the client</param>
        /// <param name="unit"></param>
        /// <returns>StationItem.</returns>
        public CallSignInfo GetCallSignInfo(string callsingId, double clientLat, double clientLon, string unit)
        {
            WebRequest req =
                WebRequest.Create(String.Format(HamdroidSentryConst.GetCallSingInfoUrl, callsingId, clientLat, clientLon,
                    unit));
            WebResponse resp = req.GetResponse();
            Stream sIn = resp.GetResponseStream();
            return DomainSerializer<CallSignInfo>.DeserializeJson(sIn);
        }

        /// <summary>
        ///     Gets the avatar.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public string GetAvatar(string url, int width, int height)
        {
            WebRequest req = WebRequest.Create(String.Format(HamdroidSentryConst.GetAvatarUrl, url, width, height));
            WebResponse resp = req.GetResponse();
            Stream sIn = resp.GetResponseStream();
            return sIn.AsBase64String();
        }

        /// <summary>
        ///     Registers the device location.
        /// </summary>
        /// <param name="deviceId">The device identifier.</param>
        /// <param name="latitude">The latitude.</param>
        /// <param name="longitude">The longitude.</param>
        /// <param name="altitude">The altitude.</param>
        /// <param name="bearing">The bearing.</param>
        /// <param name="speed">The speed.</param>
        /// <returns>DeviceLocation.</returns>
        public DeviceLocation RegisterDeviceLocation(string deviceId, double latitude, double longitude, double altitude,
            float bearing, float speed)
        {
            WebRequest req =
                WebRequest.Create(String.Format(HamdroidSentryConst.RegisterDeviceLocationUrl, deviceId, latitude,
                    longitude, altitude, bearing, speed));
            WebResponse resp = req.GetResponse();
            Stream sIn = resp.GetResponseStream();
            return DomainSerializer<DeviceLocation>.DeserializeJson(sIn);
        }
    }
}