using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Broobu.HamRadio.Contract.Domain;


namespace Broobu.ManageQso.Contract.Interfaces
{
    [ServiceContract(Namespace = ManageQsoConst.ServiceNamespace)]
    public interface IManageQso
    {
        [OperationContract]
        StationItem GetStationInfo(string callId);
        [OperationContract]
        LogbookItem[] GetLogbookItemsForStation(string callId);
        [OperationContract]
        LogbookItem[] SaveLogbookItems(LogbookItem[] items);
        [OperationContract]
        LogbookItem[] DeleteLogbookItems(LogbookItem[] items);
        [OperationContract]
        LogbookItem DeleteLogbookItem(LogbookItem item);
    }
}
