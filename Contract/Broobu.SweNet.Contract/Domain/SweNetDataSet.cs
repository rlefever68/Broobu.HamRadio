using System;
using System.Runtime.Serialization;

namespace Broobu.SweNet.Contract.Domain
{
    [DataContract]
    public class SweNetDataSet
    {
        [DataMember]
        public ExtensionDataObject ExtensionData;
        [DataMember]
        public int ColumnCount;
        [DataMember]
        public string[] ColumnNames;
        [DataMember]        
        public string[] ColumnTypes;
        [DataMember]
        public object[][] Data;
        [DataMember]        
        public DateTime EndDate;
        [DataMember]        
        public int RowCount;
        [DataMember]        
        public DateTime StartDate;
        [DataMember]        
        public string TableName;
    }
}
