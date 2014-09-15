// ***********************************************************************
// Assembly         : Broobu.Hamdroid.Business
// Author           : Rafael Lefever
// Created          : 01-19-2014
//
// Last Modified By : Rafael Lefever
// Last Modified On : 01-19-2014
// ***********************************************************************
// <copyright file="HamdroidProvider.cs" company="Broobu Systems Ltd.">
//     Copyright (c) Broobu Systems Ltd.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using Broobu.Hamdroid.Business.Interfaces;
using Broobu.Hamdroid.Business.Workers;
using Broobu.Hamdroid.Contract.Domain;
using Broobu.HamRadio.Contract.Domain;
using Broobu.LATI.Contract.Domain;

namespace Broobu.Hamdroid.Business
{
    /// <summary>
    ///     Class HamdroidProvider.
    /// </summary>
    public static class HamdroidProvider
    {
        /// <summary>
        ///     Gets the hamdroids.
        /// </summary>
        /// <value>The hamdroids.</value>
        public static IHamdroids Hamdroids
        {
            get { return new Hamdroids(); }
        }

        /// <summary>
        ///     To the call sign information.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="clientLat">The client lat.</param>
        /// <param name="clientLon">The client lon.</param>
        /// <returns>CallSignInfo.</returns>
        public static CallSignInfo ToCallSignInfo(this StationItem item)
        {
            return new CallSignInfo
            {
                BioUrl = item.Bio,
                CallSign = item.CallId,
                DisplayLocation = String.Format("{0}, {1} {2}", item.Country, item.Address2, item.State),
                DisplayName = String.Format("{0} {1}", item.FirstName, item.LastName),
                Grid = item.Grid,
                ImageUrl = item.ImageUrl,
                Latitude = Convert.ToDouble(item.Latitude),
                Longitude = Convert.ToDouble(item.Longitude)
            };
        }


        public static LocationLog ToLocationLog(this DeviceLocation item)
        {
            return new LocationLog
            {
                Bearing = item.Bearing,
                Accuracy = item.Accuracy,
                Altitude = item.Altitude,
                Latitude = item.Latitude,
                Longitude = item.Longitude,
                Speed = item.Speed,
                PoIId = item.Device
            };
        }


        /// <summary>
        ///     Unknowns the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>CallSignInfo.</returns>
        public static CallSignInfo ToUnknown(this StationItem item)
        {
            return new CallSignInfo
            {
                BioUrl = "",
                CallSign = item.CallId.ToUpper(),
                DisplayLocation = "Unknown",
                DisplayName = String.Format("{0} not found.", item.CallId.ToUpper()),
                Grid = "",
                ImageUrl = "",
                Latitude = 0.0,
                Longitude = 0.0,
                LongPath = "",
                ShortPath = "",
                Bearing = "",
                DisplayLatitude = "",
                DisplayLongitude = ""
            };
        }
    }
}