using System.Runtime.Serialization;

namespace NSB.Contracts.Services.DataContracts
{

    [DataContract]
    public class PaymentFileMatch
    {
        private string _value1;
        private string _value2;
        private bool _match = false;

        [DataMember]
        public int id { get; set; }
        [DataMember]
        public string NodeName { get; set; }
        [DataMember]
        public string Value1
        {
            get { return _value1; }
            set { _value1 = string.IsNullOrEmpty(value) ? string.Empty : value; }
        }
        [DataMember]
        public string Value2
        {
            get { return _value2; }
            set { _value2 = string.IsNullOrEmpty(value) ? string.Empty : value; }
        }
        [DataMember]
        public bool Match
        {
            get { return _value2.Trim().ToUpper() == _value1.Trim().ToUpper(); }
            set { _match = value; }
        }
        [DataMember]
        public long SourceId1 { get; set; }
        [DataMember]
        public long SourceId2 { get; set; }
    }


    [DataContract]
    public class PaymentFileMatchData
    {
        [DataMember]
        public int Index { get; set; }
        [DataMember]
        public long SourceId1 { get; set; }
        [DataMember]
        public long SourceId2 { get; set; }        
    }

    [DataContract]
    public class PaymentFileResult
    {
        [DataMember]
        public long Id { get; set; }
        [DataMember]
        public string FileBody { get; set; }
    }
}
