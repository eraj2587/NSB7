using System.Runtime.Serialization;

namespace WUBS.Contracts.Services.DataContracts
{
    [DataContract]
    [KnownType(typeof(HoldingBalance))]
    public class VirtualAccount
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string CustomerId { get; set; }

        public int CurrencyId { get; set; }

        [DataMember]
        public Currency Currency { get; set; }

        [DataMember]
        public decimal BookBalance { get; set; }

        [DataMember]
        public decimal AvailableBalance { get; set; }

        [DataMember]
        public decimal PendingBalance { get; set; }

        [DataMember]
        public decimal ReserveBalance { get; set; }

        [DataMember]
        public VirtualAccountType AccountType { get; set; }
    }

}
