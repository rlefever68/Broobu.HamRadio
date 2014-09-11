// ***********************************************************************
// Assembly         : Broobu.SweNet.Adapter
// Author           : Rafael Lefever
// Created          : 01-27-2014
//
// Last Modified By : Rafael Lefever
// Last Modified On : 01-27-2014
// ***********************************************************************
// <copyright file="SweNetAgent.cs" company="Broobu Systems Ltd.">
//     Copyright (c) Broobu Systems Ltd.. All rights reserved.
// </copyright>
// <summary></summary>
// for more info : http://esa-spaceweather.net/docs/swenet/webservice/SWENET_Webservice_Developer_Guide_01_01.pdf
// ***********************************************************************

using System;
using System.ServiceModel;
using Broobu.SweNet.Adapter.SweNet;

namespace Broobu.SweNet.Adapter.Worker
{
    /// <summary>
    /// Class SweNetAgent.
    /// </summary>
    public  class SweNetProxy : ISwenetDataProviderPortType
    {


        /// <summary>
        /// Logins the specified user name.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="passWord">The pass word.</param>
        /// <returns>System.String.</returns>
        public string login(string userName, string passWord)
        {
            var clt = new SwenetDataProviderPortTypeClient("ISwenetDataProviderHttpPort");
            try
            {
                return clt.login(userName, passWord);
            }
            finally
            {
                CloseClient(clt);
            }

        }


        /// <summary>
        /// Logouts the specified session identifier.
        /// </summary>
        /// <param name="sessionId">The session identifier.</param>
        public void logout(string sessionId)
        {
            var clt = new SwenetDataProviderPortTypeClient("ISwenetDataProviderHttpPort");
            try
            {
                clt.logout(sessionId);
            }
            finally
            {
                CloseClient(clt);
            }
        }

        
        
        
        // Expects:  String sessionId, String table, String[] columns, Date startDate, Date endDate 
        // Returns:  Object[][] data 
        // The getData method takes a session Id, table and column names, and a start and end date (the timespan). 
        // It returns a two-dimensional object array with the values; this array can be addressed with data[row][column]. 2
        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <param name="sessionId">The session identifier.</param>
        /// <param name="tableName">Name of the table.</param>
        /// <param name="columns">The columns.</param>
        /// <param name="startDate">The start date.</param>
        /// <param name="endDate">The end date.</param>
        /// <returns>ISwenetDataSet.</returns>
        public ISwenetDataSet getData(string sessionId, string tableName, ArrayOfString columns, DateTime startDate, DateTime endDate)
        {
            var clt = new SwenetDataProviderPortTypeClient("ISwenetDataProviderHttpPort");
            try
            {
                return clt.getData(sessionId, tableName, columns, startDate, endDate);
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
        /// <returns>ArrayOfString.</returns>
        public ArrayOfString getColumnNames(string sessionId, string tableName)
        {
            var clt = new SwenetDataProviderPortTypeClient("ISwenetDataProviderHttpPort");
            try
            {
                return clt.getColumnNames(sessionId, tableName);
            }
            finally
            {
                CloseClient(clt);
            }
        }

        /// <summary>
        /// Gets the table names.
        /// </summary>
        /// <param name="sessionId"></param>
        /// <returns>ArrayOfString.</returns>
        public ArrayOfString getTableNames(string sessionId)
        {
            var clt = new SwenetDataProviderPortTypeClient("ISwenetDataProviderHttpPort");
            try
            {
                return clt.getTableNames(sessionId);
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
        public DateTime getLatestDate(string sessionId, string tableName)
        {
            var clt = new SwenetDataProviderPortTypeClient("ISwenetDataProviderHttpPort");
            try
            {
                return clt.getLatestDate(sessionId, tableName);
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
        /// <returns>ArrayOfString.</returns>
        public ArrayOfString getColumnTypes(string sessionId, string tableName)
        {
            var clt = new SwenetDataProviderPortTypeClient("ISwenetDataProviderHttpPort");
            try
            {
                return clt.getColumnTypes(sessionId, tableName);
            }
            finally
            {
                CloseClient(clt);
            }
        }


        #region CloseClient

        /// <summary>
        /// Closes the client.
        /// </summary>
        /// <param name="instance">The instance.</param>
        private void CloseClient(SwenetDataProviderPortTypeClient instance)
        {
            if (instance == null) return;
            DisposeClient(instance);
        }





        /// <summary>
        /// Disposes the client.
        /// </summary>
        /// <param name="client">The client.</param>
        private static void DisposeClient(SwenetDataProviderPortTypeClient client)
        {
            if (client == null) return;
            if (client.InnerChannel != null)
            {
                client.InnerChannel.Close();
                client.InnerChannel.Dispose();
            }
            client.Abort();
        }


        #endregion


    }
}
