// ***********************************************************************
// Assembly         : Broobu.Hamdroid.Business
// Author           : Rafael Lefever
// Created          : 01-19-2014
//
// Last Modified By : Rafael Lefever
// Last Modified On : 01-23-2014
// ***********************************************************************
// <copyright file="Hamdroids.cs" company="Broobu Systems Ltd.">
//     Copyright (c) Broobu Systems Ltd.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using Broobu.Hamdroid.Business.Interfaces;
using Broobu.Hamdroid.Contract.Domain;
using Broobu.HamRadio.Business;
using Broobu.HamRadio.Contract.Domain;
using Broobu.LATI.Contract;
using Broobu.LATI.Contract.Domain;
using NLog;
using Wulka.Exceptions;
using Wulka.Utils;
using Wulka.Utils.Geo;

namespace Broobu.Hamdroid.Business.Workers
{
    /// <summary>
    ///     Class Hamdroids.
    /// </summary>
    internal class Hamdroids : IHamdroids
    {
        /// <summary>
        ///     Gets the logger.
        /// </summary>
        /// <value>The logger.</value>
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

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
            id = id.ToUpper();
            CallSignInfo res = null;
            StationItem it = HamRadioProvider.HamRadio
                .GetStationInfo(id);
            if (it.SessionId == "UNKNOWN")
            {
                res = it.ToUnknown();
            }
            else
            {
                res = it.ToCallSignInfo();
                res.LongPath = GetLongPath(it, clientLat, clientLon, unit);
                res.ShortPath = GetShortPath(it, clientLat, clientLon, unit);
                res.Bearing = GetBearing(it, clientLat, clientLon);
                res.DisplayLatitude =
                    GeoAngle.FromDouble(Convert.ToDouble(it.Latitude)).ToString(LocationFormat.Latitude);
                res.DisplayLongitude =
                    GeoAngle.FromDouble(Convert.ToDouble(it.Longitude)).ToString(LocationFormat.Longtitude);
            }
            res.YourDisplayLatitude = GeoAngle.FromDouble(clientLat).ToString(LocationFormat.Latitude);
            res.YourDisplayLongitude = GeoAngle.FromDouble(clientLon).ToString(LocationFormat.Longtitude);
            res.YourGrid = CalculateGrid(clientLat, clientLon);
            return res;
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
            return ImageUtils.GetAvatarBase64(url, width, height, true);
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
            DeviceLocation loc = null;
            try
            {
                loc = new DeviceLocation
                {
                    Device = deviceId,
                    Accuracy = (float) 0.0,
                    Altitude = altitude,
                    Bearing = bearing,
                    Speed = speed,
                    Latitude = latitude,
                    Longitude = longitude,
                    DisplayAltitude = String.Format("{0:n0}m", altitude),
                    DisplayBearing = GeoAngle.FromDouble(bearing).ToString(),
                    DisplayGrid = CalculateGrid(latitude, longitude),
                    DisplayLatitude = GeoAngle.FromDouble(latitude).ToString(LocationFormat.Latitude),
                    DisplayLongitude = GeoAngle.FromDouble(longitude).ToString(LocationFormat.Longtitude),
                    DisplaySpeed = String.Format("{0:n1}m/s", speed)
                };
                LocationLog locLog = loc.ToLocationLog();
                locLog = LatiPortal
                    .Latis
                    .RegisterLocation(locLog);
                return loc;
            }
            catch (Exception exception)
            {
                _logger.Error(exception.GetCombinedMessages());
                return loc;
            }
        }


        /// <summary>
        ///     Gets the long path.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="clientLat">The client lat.</param>
        /// <param name="clientLon">The client lon.</param>
        /// <param name="unit">The unit.</param>
        /// <returns>System.String.</returns>
        public string GetLongPath(StationItem item, double clientLat, double clientLon, string unit)
        {
            double lat = Convert.ToDouble(item.Latitude);
            double lon = Convert.ToDouble(item.Longitude);
            var res = Convert.ToString(
                unit == "mi"
                    ? GeoUtils.LongDistanceTo(clientLat, lat, clientLon, lon, DistanceType.Miles)
                    : GeoUtils.LongDistanceTo(clientLat, lat, clientLon, lon, DistanceType.Kilometers));
            return String.Format(unit == "mi" ? "{0} Mi" : "{0} km", res);
        }

        /// <summary>
        ///     Gets the short path.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="clientLat">The client lat.</param>
        /// <param name="clientLon">The client lon.</param>
        /// <param name="unit">The unit.</param>
        /// <returns>System.String.</returns>
        public static string GetShortPath(StationItem item, double clientLat, double clientLon, string unit)
        {
            double lat = Convert.ToDouble(item.Latitude);
            double lon = Convert.ToDouble(item.Longitude);
            var res = Convert.ToString(
                unit == "mi"
                    ? GeoUtils.DistanceTo(clientLat, lat, clientLon, lon, DistanceType.Miles)
                    : GeoUtils.DistanceTo(clientLat, lat, clientLon, lon, DistanceType.Kilometers));
            return String.Format(unit == "mi" ? "{0} Mi" : "{0} km", res);
        }

        /// <summary>
        ///     Gets the bearing.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="clientLat">The client lat.</param>
        /// <param name="clientLon">The client lon.</param>
        /// <returns>System.String.</returns>
        public static string GetBearing(StationItem item, double clientLat, double clientLon)
        {
            double lat = Convert.ToDouble(item.Latitude);
            double lon = Convert.ToDouble(item.Longitude);
            return GeoAngle.FromDouble(GeoUtils.BearingTo(clientLat, lat, clientLon, lon)).ToString();
        }


        /// <summary>
        ///     Calculates the grid.
        /// </summary>
        /// <param name="lat">The lat.</param>
        /// <param name="lon">The lon.</param>
        /// <returns>System.String.</returns>
        public static string CalculateGrid(double lat, double lon)
        {
            lon = lon + 180;
            lat = lat + 90;
            var c1 = (char) ('A' + Convert.ToInt32(Math.Truncate(lon/20)));
            var c2 = (char) ('A' + Convert.ToInt32(Math.Truncate(lat/10)));
            var c3 = (char) ('0' + Convert.ToInt32(Math.Truncate((lon%20)/2)));
            var c4 = (char) ('0' + Convert.ToInt32(Math.Truncate((lat%10)/1)));
            double res = (lon - (2*Math.Truncate(lon/2)))*12;
            var c5 = (char) ('a' + Convert.ToInt32(res));
            res = (lat - (Math.Truncate(lat)))*24;
            var c6 = (char) ('a' + Convert.ToInt32(res));
            string grid = String.Format("{0}{1}{2}{3}{4}{5}", c1, c2, c3, c4, c5, c6);
            return grid;
        }
    }
}