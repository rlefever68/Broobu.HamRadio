// ***********************************************************************
// Assembly         : Broobu.ManageQso.Business
// Author           : Rafael Lefever
// Created          : 12-17-2013
//
// Last Modified By : Rafael Lefever
// Last Modified On : 01-16-2014
// ***********************************************************************
// <copyright file="ManageQsoProvider.cs" company="Broobu Systems Ltd.">
//     Copyright (c) Broobu Systems Ltd.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Broobu.ManageQso.Business.Interfaces;
using Broobu.ManageQso.Business.Providers;



namespace Broobu.ManageQso.Business
{
    /// <summary>
    /// Class ManageQsoProviderFactory.
    /// </summary>
    public static class ManageQsoProvider
    {
        /// <summary>
        /// Creates the manage qso provider.
        /// </summary>
        /// <value>The manage qsos.</value>
        /// <returns>IManageQsoProvider.</returns>
        public static IManageQsos ManageQsos
        {
            get 
            {
                return new ManageQsos();
            }
        }

    }
}
