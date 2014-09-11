using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Broobu.SweNet.Adapter;
using Broobu.SweNet.Adapter.SweNet;
using Broobu.Swenet.Business;
using Broobu.SweNet.Business.Interfaces;
using Broobu.SweNet.Contract.Domain;

namespace Broobu.SweNet.Business.Workers
{
    /// <summary>
    /// Class SweNetWorker.
    /// </summary>
    class SweNetWorker : ISweNetWorker
    {
        /// <summary>
        /// Logouts the specified session identifier.
        /// </summary>
        /// <param name="sessionId">The session identifier.</param>
        public void Logout(string sessionId)
        {
            SweNetAdapter
                .Proxy
                .logout(sessionId);
        }

        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <param name="sessionId">The session identifier.</param>
        /// <param name="tableName">Name of the table.</param>
        /// <param name="columns">The columns.</param>
        /// <param name="startDate">The start date.</param>
        /// <param name="endDate">The end date.</param>
        /// <returns>Broobu.SweNet.Contract.Domain.SweNetDataSet.</returns>
        public SweNetDataSet GetData(string sessionId, string tableName, string[] columns, DateTime startDate, DateTime endDate)
        {
            ArrayOfString columnsArray = new ArrayOfString();
            columnsArray.AddRange(columns);
            ISwenetDataSet res = SweNetAdapter
                .Proxy
                .getData(sessionId, tableName, columnsArray, startDate, endDate);
            return res.ToSweNetDataSet();

        }

        /// <summary>
        /// Gets the column names.
        /// </summary>
        /// <param name="sessionId">The session identifier.</param>
        /// <param name="tableName">Name of the table.</param>
        /// <returns>System.String.</returns>
        public string[] GetColumnNames(string sessionId, string tableName)
        {
            return SweNetAdapter
                .Proxy
                .getColumnNames(sessionId, tableName).ToArray();
        }

        /// <summary>
        /// Gets the table names.
        /// </summary>
        /// <param name="sessionId">The session identifier.</param>
        /// <returns>System.String[].</returns>
        public string[] GetTableNames(string sessionId)
        {
            return SweNetAdapter
                .Proxy
                .getTableNames(sessionId).ToArray();
        }

        /// <summary>
        /// Gets the latest date.
        /// </summary>
        /// <param name="sessionId">The session identifier.</param>
        /// <param name="tableName">Name of the table.</param>
        /// <returns>System.DateTime.</returns>
        public DateTime GetLatestDate(string sessionId, string tableName)
        {
            return SweNetAdapter
                .Proxy
                .getLatestDate(sessionId, tableName);
        }

        /// <summary>
        /// Gets the column types.
        /// </summary>
        /// <param name="sessionId">The session identifier.</param>
        /// <param name="tableName">Name of the table.</param>
        /// <returns>System.String[].</returns>
        public string[] GetColumnTypes(string sessionId, string tableName)
        {
            return SweNetAdapter
                .Proxy
                .getColumnTypes(sessionId, tableName).ToArray();
        }

        /// <summary>
        /// Logins the specified user name.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        /// <returns>System.String.</returns>
        public string Login(string userName, string password)
        {
            return SweNetAdapter
                .Proxy
                .login(userName, password);
        }
    }
}
