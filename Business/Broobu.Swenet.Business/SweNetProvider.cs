using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Broobu.SweNet.Adapter.SweNet;
using Broobu.SweNet.Business.Interfaces;
using Broobu.SweNet.Business.Workers;
using Broobu.SweNet.Contract.Domain;

namespace Broobu.Swenet.Business
{

    /// <summary>
    /// Class SweNetProvider.
    /// </summary>
    public static class SweNetProvider
    {
        /// <summary>
        /// Gets the worker.
        /// </summary>
        /// <value>The worker.</value>
        public static ISweNetWorker Worker {
            get { 
                return new SweNetWorker();
            }
        }



        /// <summary>
        /// To the swe net data set.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>Broobu.SweNet.Contract.Domain.SweNetDataSet.</returns>
        public static SweNetDataSet ToSweNetDataSet(this ISwenetDataSet item)
        {
            return new SweNetDataSet
            {
                ColumnCount = item.columnCount,
                ColumnNames = item.columnNames.ToArray(),
                ColumnTypes = item.columnTypes.ToArray(),
                Data = item.data.ToObjectMatrix(),
                EndDate = item.endDate,
                ExtensionData = item.ExtensionData,
                RowCount = item.rowCount,
                StartDate = item.startDate,
                TableName = item.tableName
            };
        }

        /// <summary>
        /// To the object matrix.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>System.Object[][].</returns>
        public static object[][] ToObjectMatrix(this ArrayOfArrayOfAnyType item)
        {
            return item.Select(it => it.ToArray()).ToArray();
        }


    }
}
