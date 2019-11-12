using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using WUBS.Contracts.Services.DataContracts.Orders;

namespace WUBS.Contracts.Services.DataContracts.CurrencyContracts
{
    [DataContract]
    [KnownType(typeof(DistinctContractQuery))]
    [KnownType(typeof(CustomerContractsQuery))]
    public abstract class ContractQuery
    {
        [DataMember]
        public string CustomerId { get; set; }
    }

    [DataContract]
    public class DistinctContractQuery : ContractQuery
    {
        [DataMember]
        public string ContractId { get; set; }
    }

    [DataContract]
    public class CustomerContractsQuery : ContractQuery
    {
        [DataMember]
        public List<string> Ids { get; set; }
        [DataMember]
        public ContractType Type { get; set; }
        [DataMember]
        public ContractStatus Status { get; set; }
        [DataMember]
        public string SettlementCurrency { get; set; }
        [DataMember]
        public string Currency { get; set; }
        [DataMember]
        public TradeDirection Direction { get; set; }
        [DataMember]
        public bool Open { get; set; }
        [DataMember]
        public int CurrentPage { get; set; }
        [DataMember]
        public int ItemsPerPage { get; set; }
        [DataMember]
        public ContractSortColumn SortBy { get; set; }
        [DataMember]
        public SortOrder SortOrder { get; set; }
        [DataMember]
        public DateTime? BookingDateFrom { get; set; }
        [DataMember]
        public DateTime? BookingDateTo { get; set; }
        [DataMember]
        public DateTime? StartingDateFrom { get; set; }
        [DataMember]
        public DateTime? StartingDateTo { get; set; }
        [DataMember]
        public DateTime? EndingDateFrom { get; set; }
        [DataMember]
        public DateTime? EndingDateTo { get; set; }
    }

    [DataContract]
    public class DrawdownQuery
    {
        [DataMember]
        public string CustomerId { get; set; }
        [DataMember]
        public string ContractId { get; set; }
        [DataMember]
        public int CurrentPage { get; set; }
        [DataMember]
        public int ItemsPerPage { get; set; }
        [DataMember]
        public DrawdownSortColumn SortBy { get; set; }
        [DataMember]
        public SortOrder SortOrder { get; set; }
    }

    [DataContract]
    public class ContractActivityQuery
    {
        [DataMember]
        public string ContractId { get; set; }
        [DataMember]
        public bool IncludeDrawdowns { get; set; }
        [DataMember]
        public int CurrentPage { get; set; }
        [DataMember]
        public int ItemsPerPage { get; set; }
        [DataMember]
        public ContractActivitySortColumn SortBy {get; set;}
        [DataMember]
        public SortOrder SortOrder { get; set; }
    }

    [DataContract]
    public enum ContractSortColumn
    {
        [EnumMember]
        Id,
        [EnumMember]
        Status,
        [EnumMember]
        Contact,
        [EnumMember]
        BookingDate,
        [EnumMember]
        CreatedBy,
        [EnumMember]
        StartingDate, 
        [EnumMember]
        EndingDate,  
        [EnumMember]
        ContractReference,
        [EnumMember]
        Direction,
        [EnumMember]
        TradeBookedAmount, 
        [EnumMember]
        TradeCurrency,       
        [EnumMember]
        SettlementBookedAmount,
        [EnumMember]
        SettlementCurrency,
        [EnumMember]
        Rate
    }

    [DataContract]
    public enum DrawdownSortColumn
    {
        [EnumMember]
        ItemId,
        [EnumMember]
        BookingDate,
        [EnumMember]
        CreatedBy,
        [EnumMember]
        OrderReference,
        [EnumMember]
        DrawdownAmount,
        [EnumMember]
        DrawdownCurrency,
        [EnumMember]
        SettlementAmount,
        [EnumMember]
        SettlementCurrency,
    }

    [DataContract]
    public enum QueryContractType : byte
    {
        [EnumMember]
        Spot = 1,
        [EnumMember]
        Forward = 2
    }

    [DataContract]
    public enum QueryTradeDirection
    {
        [EnumMember]
        Buy = 1,
        [EnumMember]
        Sell = 2
    }

    [DataContract]
    public enum QueryContractStatus
    {
        [EnumMember]
        Undefined = 0,
        [EnumMember]
        Booked = 1,
        [EnumMember]
        Cancelled = 2,
        [EnumMember]
        Completed = 3,
        [EnumMember]
        Expired = 4,
    }

    [DataContract]
    public enum ContractActivitySortColumn
    {
        [EnumMember]
        Activity,
        [EnumMember]
        ActivityDate,
        [EnumMember]
        ActivityBy,
        [EnumMember]
        OrderAmount,
        [EnumMember]
        OrderCurrency,
        [EnumMember]
        OrderReference,
    }
}
