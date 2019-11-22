using System.Runtime.Serialization;

namespace NSB.Contracts.Services.DataContracts.LineItems
{
    [DataContract(Namespace = "http://schemas.business.test.com/2015/10/Opp")]
    public class GetLineItemByReferenceIdRequest
    {
        [DataMember]
        public string ReferenceId;

        [DataMember] public int MaxResults;
    }
}
