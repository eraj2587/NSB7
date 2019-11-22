using System.Runtime.Serialization;

namespace NSB.Contracts.Services.Faults
{
    [DataContract]
    public class FuturePaymentEventLogNotProcessedFault
    {
        [DataMember]
        public int LineItemId { get; internal set; }

        public FuturePaymentEventLogNotProcessedFault(int lineItemId)
        {
            LineItemId = lineItemId;
        }
    }
}
