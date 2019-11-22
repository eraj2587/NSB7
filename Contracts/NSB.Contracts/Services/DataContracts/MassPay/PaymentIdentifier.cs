using System.Runtime.Serialization;

namespace NSB.Contracts.Services.DataContracts.MassPay
{
    [DataContract(Namespace = "http://schemas.business.test.com/2015/10/Opp")]
    public class PaymentIdentifier
    {
        [DataMember] public string CustomerPaymentId;
        [DataMember] public string PartnerCustomerId;
        [DataMember] public string PartnerName;
    }
}
