// ***********************************************************************
// Assembly         : Broobu.HamRadio.Business
// Author           : Rafael Lefever
// Created          : 12-17-2013
//
// Last Modified By : Rafael Lefever
// Last Modified On : 01-19-2014
// ***********************************************************************
// <copyright file="HamRadioProvider.cs" company="Broobu Systems Ltd.">
//     Copyright (c) Broobu Systems Ltd.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using Broobu.HamRadio.Business.Interfaces;
using Broobu.HamRadio.Business.Providers;
using Broobu.HamRadio.Contract.Domain;
using Broobu.Qrz.Contract.Domain;

namespace Broobu.HamRadio.Business
{
    /// <summary>
    ///     Class HamRadioProvider.
    /// </summary>
    public static class HamRadioProvider
    {
        /// <summary>
        ///     Gets the ham radio.
        /// </summary>
        /// <value>The ham radio.</value>
        public static IHamRadioProvider HamRadio
        {
            get { return new HamRadios(); }
        }


        /// <summary>
        ///     To the station item.
        /// </summary>
        /// <param name="res">The resource.</param>
        /// <returns>StationItem.</returns>
        public static StationItem ToStationItem(this CallSign res)
        {
            return new StationItem
            {
                Id = res.user,
                Address1 = res.addr1,
                Address2 = res.addr2,
                AreaCode = res.AreaCode,
                Bio = res.bio,
                Born = res.born,
                CallId = res.call,
                Class = res.Class,
                Codes = res.codes,
                Country = res.country,
                County = res.county,
                CqZone = res.cqzone,
                DST = res.DST,
                EQsl = res.eqsl,
                EfDate = res.efdate,
                Email = res.email,
                ExpDate = res.expdate,
                Fips = res.fips,
                FirstName = res.fname,
                GmtOffset = res.GMTOffset,
                Grid = res.grid,
                ImageUrl = res.image,
                Iota = res.iota,
                ItuZone = res.ituzone,
                Land = res.land,
                LastName = res.name,
                Latitude = res.lat,
                LocRef = res.locref,
                Longitude = res.lon,
                Lotw = res.lotw,
                MQsl = res.mqsl,
                ModDate = res.moddate,
                Msa = res.MSA,
                PCall = res.p_call,
                QslManager = res.qslmgr,
                State = res.state,
                TimeZone = res.TimeZone,
                Trustee = res.trustee,
                UViews = res.u_views,
                User = res.user,
                Url = res.url,
                Zip = res.zip
            };
        }
    }
}