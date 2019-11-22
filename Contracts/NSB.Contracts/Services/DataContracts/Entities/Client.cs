using System.Runtime.Serialization;

namespace NSB.Contracts.Services.DataContracts
{
    [DataContract]
    public class Client
    {
        [DataMember]
        public string Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string TradePartyReference1 { get; set; }
        [DataMember]
        public string TradePartyReference2 { get; set; }
        [DataMember]
        public string TradePartyReference3 { get; set; }
        [DataMember]
        public string TradePartyReference4 { get; set; }
        [DataMember]
        public string TradePartyReference5 { get; set; }
        [DataMember]
        public string DealerOrClientOwner { get; set; }
    }
}

