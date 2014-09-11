// ***********************************************************************
// Assembly         : Broobu.SweNet.Contract
// Author           : Rafael Lefever
// Created          : 01-28-2014
//
// Last Modified By : Rafael Lefever
// Last Modified On : 01-28-2014
// ***********************************************************************
// <copyright file="SwenetAgent.cs" company="Broobu Systems Ltd.">
//     Copyright (c) Broobu Systems Ltd.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using Broobu.SweNet.Contract.Domain;
using Broobu.SweNet.Contract.Interfaces;
using Iris.Fx.Networking.Wcf;

namespace Broobu.SweNet.Contract.Agent
{
    /// <summary>
    /// Class SwenetAgent.
    /// </summary>
    class SweNetAgent : DiscoProxy<ISweNet>, ISweNetAgent
    {
        /// <summary>
        /// Logouts the specified session identifier.
        /// </summary>
        /// <param name="sessionId">The session identifier.</param>
        public void Logout(string sessionId)
        {
            var clt = CreateClient();
            try
            {
                clt.Logout(sessionId);
            }
            finally
            {
                CloseClient(clt);
            }
        }

        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <param name="sessionId">The session identifier.</param>
        /// <param name="tableName">Name of the table.</param>
        /// <param name="columns">The columns.</param>
        /// <param name="startDate">The start date.</param>
        /// <param name="endDate">The end date.</param>
        /// <returns>SwenetDataSet.</returns>
        public SweNetDataSet GetData(string sessionId, string tableName, string[] columns, DateTime startDate, DateTime endDate)
        {
            var clt = CreateClient();
            try
            {
                return clt.GetData(sessionId, tableName, columns, startDate, endDate);
            }
            finally
            {
                CloseClient(clt);
            }
        }

        /// <summary>
        /// Gets the column names.
        /// </summary>
        /// <param name="sessionId">The session identifier.</param>
        /// <param name="tableName">Name of the table.</param>
        /// <returns>System.String.</returns>
        public string[] GetColumnNames(string sessionId, string tableName)
        {
            var clt = CreateClient();
            try
            {
                return clt.GetColumnNames(sessionId, tableName);
            }
            finally
            {
                CloseClient(clt);
            }
        }

        /// <summary>
        /// Gets the table names.
        /// </summary>
        /// <param name="sessionId">The session identifier.</param>
        /// <returns>System.String[][].</returns>
        public string[] GetTableNames(string sessionId)
        {
            var clt = CreateClient();
            try
            {
                return clt.GetTableNames(sessionId);
            }
            finally
            {
                CloseClient(clt);
            }
        }

        /// <summary>
        /// Gets the latest date.
        /// </summary>
        /// <param name="sessionId">The session identifier.</param>
        /// <param name="tableName">Name of the table.</param>
        /// <returns>DateTime.</returns>
        public DateTime GetLatestDate(string sessionId, string tableName)
        {
            var clt = CreateClient();
            try
            {
                return clt.GetLatestDate(sessionId, tableName);
            }
            finally
            {
                CloseClient(clt);
            }
        }

        /// <summary>
        /// Gets the column types.
        /// </summary>
        /// <param name="sessionId">The session identifier.</param>
        /// <param name="tableName">Name of the table.</param>
        /// <returns>System.String[][].</returns>
        public string[] GetColumnTypes(string sessionId, string tableName)
        {
            var clt = CreateClient();
            try
            {
                return clt.GetColumnTypes(sessionId, tableName);
            }
            finally
            {
                CloseClient(clt);
            }
        }

        /// <summary>
        /// Logins the specified user name.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        /// <returns>System.String.</returns>
        public string Login(string userName, string password)
        {
            var clt = CreateClient();
            try
            {
                return clt.Login(userName, password);
            }
            finally
            {
                CloseClient(clt);
            }
        }
    }
}
