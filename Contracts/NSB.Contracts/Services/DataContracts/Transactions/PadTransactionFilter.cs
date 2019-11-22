using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace NSB.Contracts.Services.DataContracts.Transactions
{
    [DataContract]
    public class PadTransactionFilter
    {
        [DataMember]
        public int MaxRowsToReturn { get; set; }

        [DataMember]
        public int PageNumber { get; set; }

        [DataMember]
        public int PageSize { get; set; }

        [DataMember]
        public string ConfirmationNumber { get; set; }

        [DataMember]
        public int OfficeId { get; set; }

        [DataMember]
        public List<int> DealerIds { get; set; }

        [DataMember]
        public DateTime? StartDate { get; set; }

        [DataMember]
        public DateTime? EndDate { get; set; }

        [DataMember]
        public List<int> WorkflowStatus { get; set; }

        [DataMember]
        public int LoggedInUserId { get; set; }

        [DataMember]
        public int ClientId { get; set; }
    }
}
