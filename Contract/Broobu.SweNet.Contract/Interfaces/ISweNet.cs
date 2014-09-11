using System;
using System.ServiceModel;
using Broobu.SweNet.Contract.Domain;

namespace Broobu.SweNet.Contract.Interfaces
{
    [ServiceContract]
    public interface ISweNet
    {
        [OperationContract]
        void Logout(string sessionId);
        [OperationContract]
        SweNetDataSet GetData(string sessionId, string tableName, string[] columns, DateTime startDate, DateTime endDate);
        [OperationContract]
        string[] GetColumnNames(string sessionId, string tableName);
        [OperationContract]
        string[] GetTableNames(string sessionId);
        [OperationContract]
        DateTime GetLatestDate(string sessionId, string tableName);
        [OperationContract]
        string[] GetColumnTypes(string sessionId, string tableName);
        [OperationContract]
        string Login(string userName, string password);
    }
}
