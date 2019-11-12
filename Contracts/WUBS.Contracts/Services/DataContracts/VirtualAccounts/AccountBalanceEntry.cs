using System.Runtime.Serialization;

namespace WUBS.Contracts.Services.DataContracts
{

    [DataContract]
    public enum VirtualAccountType
    {
        [EnumMember]
        None = 0,
        [EnumMember]
        Holding = 1
    }

    //public enum VirtualAccountStatus
    //{
    //    Active,
    //    Inactive
    //}
    //[DataContract]
    //public enum VirtualItemStatus
    //{
    //    [EnumMember]
    //    Reserved,
    //    [EnumMember]
    //    Pending,
    //    [EnumMember]
    //    BookUpdated,
    //    [EnumMember]
    //    Drawdown,
    //    [EnumMember]
    //    Deposit
    //}

    //public enum CCTHoldingItemsStatus
    //{
    //    Deleted,
    //    Error,
    //    InProcess,
    //    NotPosted,
    //    Posted
    //}

    [DataContract]
    public enum PendingItemsStatus
    {
        [EnumMember]
        Deleted,
        [EnumMember]
        Error,
        [EnumMember]
        InProcess,
        [EnumMember]
        NotPosted,
        [EnumMember]
        Posted
    }


    [DataContract]
    public class AccountBalanceEntry
    {
        [DataMember]
        public int CustomerId { get; set; }

        [DataMember]
        public VirtualAccountType VirtualAccountType { get; set; }

        [DataMember]
        public string Currency { get; set; }

        [DataMember]
        public int ItemId { get; set; }

        [DataMember]
        public decimal Amount { get; set; }

        [DataMember]
        public bool IsCredit { get; set; }

        [DataMember]
        public int UserId { get; set; }
    }

    [DataContract]
    public class PendingBalanceQuery
    {
        [DataMember]
        public string CustomerId { get; set; }

        [DataMember]
        public Currency[] Currencies { get; set; }

        [DataMember]
        public PendingItemsStatus PendingItemsStatus { get; set; }

        [DataMember]
        public bool IncludeBuild { get; set; }
    }
}
