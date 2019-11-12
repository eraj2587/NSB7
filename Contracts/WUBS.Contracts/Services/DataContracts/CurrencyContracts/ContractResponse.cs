using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WUBS.Contracts.Services.DataContracts.CurrencyContracts
{
    [DataContract]
    public class PagingResponse
    {
        [DataMember]
        public int CurrentPage { get; set; }

        [DataMember]
        public int ItemsPerPage { get; set; }

        [DataMember]
        public int TotalPages { get; set; }

        [DataMember]
        public int TotalItems { get; set; }
    }

    [DataContract]

    public class ContractResponse : PagingResponse
    {
        [DataMember]
        public List<Contract> Contracts;
    }

    [DataContract]
    public class DrawdownResponse : PagingResponse
    {
        [DataMember]
        public List<AutoForwardContractDrawdown> Drawdowns;
    }

    [DataContract]
    public class ContractActivityResponse: PagingResponse
    {
        [DataMember]
        public List<ContractActivity> Activities;
    }
}
