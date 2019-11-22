using System;
using System.Runtime.Serialization;

namespace NSB.Contracts.Services.DataContracts
{
    [DataContract]
    public class HoldingBalance : VirtualAccount
    {
        [DataMember]
        public string Customer { get; set; }

        [DataMember]
        public DateTime InquiryDate { get; set; }
    }
}
