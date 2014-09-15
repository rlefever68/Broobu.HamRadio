// ***********************************************************************
// Assembly         : Broobu.Hamdroid.Rest
// Author           : Rafael Lefever
// Created          : 01-19-2014
//
// Last Modified By : Rafael Lefever
// Last Modified On : 01-19-2014
// ***********************************************************************
// <copyright file="HamdroidSentry.cs" company="Broobu Systems Ltd.">
//     Copyright (c) Broobu Systems Ltd.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using Broobu.Hamdroid.Business;
using Broobu.Hamdroid.Contract.Domain;
using Broobu.Hamdroid.Contract.Interfaces;

namespace Broobu.Hamdroid.Rest
{
    /// <summary>
    ///     Class HamdroidSentry.
    /// </summary>
    public class HamdroidSentry : IHamdroid
    {
        /// <summary>
        ///     Gets the call sign information.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="clientLat">The client lat.</param>
        /// <param name="clientLon">The client lon.</param>
        /// <param name="unit">The unit.</param>
        /// <returns>CallSignInfo.</returns>
        public CallSignInfo GetCallSignInfo(string id, double clientLat, double clientLon, string unit)
        {
            return HamdroidProvider
                .Hamdroids
                .GetCallSignInfo(id, clientLat, clientLon, unit);
        }

        /// <summary>
        ///     Gets the avatar.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <returns>System.String.</returns>
        public string GetAvatar(string url, int width, int height)
        {
            return HamdroidProvider
                .Hamdroids
                .GetAvatar(url, width, height);
        }

        /// <summary>
        ///     Registers the device location.
        /// </summary>
        /// <param name="deviceId">The device identifier.</param>
        /// <param name="latitude">The latitude.</param>
        /// <param name="longitude">The longitude.</param>
        /// <param name="height">The height.</param>
        /// <returns>DeviceLocation.</returns>
        public DeviceLocation RegisterDeviceLocation(string deviceId, double latitude, double longitude, double altitude,
            float bearing, float speed)
        {
            return HamdroidProvider
                .Hamdroids
                .RegisterDeviceLocation(deviceId, latitude, longitude, altitude, bearing, speed);
        }
    }
}