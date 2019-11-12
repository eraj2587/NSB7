using System.Runtime.Serialization;

namespace WUBS.Contracts.Services.DataContracts.MassPay
{
    [DataContract(Namespace = "http://schemas.business.westernunion.com/2015/10/Opp")]
    public class PaymentIdentifier
    {
        [DataMember] public string CustomerPaymentId;
        [DataMember] public string PartnerCustomerId;
        [DataMember] public string PartnerName;
    }
}
