using System.Collections.Generic;
using System.Runtime.Serialization;

namespace NSB.Contracts.Services.DataContracts
{
    [DataContract]
    public class VirtualAccountActivityResponse
    {
        [DataMember]
        public long CurrentPage { get; set; }

        [DataMember]
        public long ItemsPerPage { get; set; }

        [DataMember]
        public long TotalPages { get; set; }

        [DataMember]
        public long TotalItems { get; set; }

        [DataMember]
        public List<VirtualAccountActivity> Activities { get; set; }
    }
}