// ***********************************************************************
// Assembly         : Broobu.SweNet.Service
// Author           : Rafael Lefever
// Created          : 01-28-2014
//
// Last Modified By : Rafael Lefever
// Last Modified On : 01-28-2014
// ***********************************************************************
// <copyright file="SweNetSentry.cs" company="Broobu Systems Ltd.">
//     Copyright (c) Broobu Systems Ltd.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using Broobu.Swenet.Business;
using Broobu.SweNet.Contract.Domain;
using Broobu.SweNet.Contract.Interfaces;


namespace Broobu.SweNet.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    /// <summary>
    /// Class SweNetSentry.
    /// </summary>
    public class SweNetSentry : ISweNet
    {
        /// <summary>
        /// Logouts the specified session identifier.
        /// </summary>
        /// <param name="sessionId">The session identifier.</param>
        public void Logout(string sessionId)
        {
            SweNetProvider
                .Worker
                .Logout(sessionId);
        }

        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <param name="sessionId">The session identifier.</param>
        /// <param name="tableName">Name of the table.</param>
        /// <param name="columns">The columns.</param>
        /// <param name="startDate">The start date.</param>
        /// <param name="endDate">The end date.</param>
        /// <returns>SweNetDataSet.</returns>
        public SweNetDataSet GetData(string sessionId, string tableName, string[] columns, DateTime startDate, DateTime endDate)
        {
            return SweNetProvider
                .Worker
                .GetData(sessionId, tableName, columns, startDate, endDate);
        }

        /// <summary>
        /// Gets the column names.
        /// </summary>
        /// <param name="sessionId">The session identifier.</param>
        /// <param name="tableName">Name of the table.</param>
        /// <returns>System.String.</returns>
        public string[] GetColumnNames(string sessionId, string tableName)
        {
            return SweNetProvider
                .Worker
                .GetColumnNames(sessionId, tableName);
        }

        /// <summary>
        /// Gets the table names.
        /// </summary>
        /// <param name="sessionId">The session identifier.</param>
        /// <returns>System.String[][].</returns>
        public string[] GetTableNames(string sessionId)
        {
            return SweNetProvider
                .Worker
                .GetTableNames(sessionId);
        }

        /// <summary>
        /// Gets the latest date.
        /// </summary>
        /// <param name="sessionId">The session identifier.</param>
        /// <param name="tableName">Name of the table.</param>
        /// <returns>DateTime.</returns>
        public DateTime GetLatestDate(string sessionId, string tableName)
        {
            return SweNetProvider
                .Worker
                .GetLatestDate(sessionId, tableName);
        }

        /// <summary>
        /// Gets the column types.
        /// </summary>
        /// <param name="sessionId">The session identifier.</param>
        /// <param name="tableName">Name of the table.</param>
        /// <returns>System.String[][].</returns>
        public string[] GetColumnTypes(string sessionId, string tableName)
        {
            return SweNetProvider
                .Worker
                .GetColumnTypes(sessionId, tableName);
        }

        /// <summary>
        /// Logins the specified user name.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        /// <returns>System.String.</returns>
        public string Login(string userName, string password)
        {
            return SweNetProvider
                .Worker
                .Login(userName, password);
        }
    }
}
