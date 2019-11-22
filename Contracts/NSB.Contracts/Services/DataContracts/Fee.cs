using System.Runtime.Serialization;

namespace NSB.Contracts.Services.DataContracts
{
    [DataContract]
    public class Fee
    {
        [DataMember]
        public FeeType FeeType { get; set; }

        [DataMember]
        public string Code { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public decimal Amount { get; set; }
    }
}
