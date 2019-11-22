using System;
using System.Runtime.Serialization;

namespace NSB.Contracts.Services.DataContracts
{
    [DataContract]
    public class VirtualAccountActivityQuery
    {
        [DataMember]
        public string CustomerId { get; set; }

        [DataMember]
        public Currency Currency { get; set; }

        [DataMember]
        public VirtualAccountType VirtualAccountType { get; set; }

        [DataMember]
        public bool IncludeCredit { get; set; }

        [DataMember]
        public bool IncludeDebit { get; set; }

        [DataMember]
        public DateTimeOffset StartDate { get; set; }

        [DataMember]
        public DateTimeOffset EndDate { get; set; }

        [DataMember]
        public int CurrentPage { get; set; }

        [DataMember]
        public int ItemsPerPage { get; set; }

        [DataMember]
        public VirtualAccountActivitySortColumn SortBy { get; set; }

        [DataMember]
        public SortOrder SortOrder { get; set; }
    }

    [DataContract]
    public enum VirtualAccountActivitySortColumn
    {
        [EnumMember]
        ActivityDate,
        [EnumMember]
        TransactionDate
    }

    [DataContract]
    public enum SortOrder
    {
        [EnumMember]
        ASC,
        [EnumMember]
        DESC
    }

}