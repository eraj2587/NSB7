using System;
using System.Runtime.Serialization;

namespace NSB.Contracts.Services.DataContracts.LineItems
{
    [DataContract(Namespace = "http://schemas.business.test.com/2015/10/Opp")]
    public class LineItem
    {
        [DataMember]
        public string ConfirmationNumber;
        [DataMember]
        public int LineItemNumber;
        [DataMember]
        public string ExternalOrderId;
        [DataMember]
        public string ExternalPaymentId;
        [DataMember]
        public LineItemType LineItemType;
        [DataMember]
        public DateTimeOffset? OrderDate;
        [DataMember]
        public string FxCurrencyCode;
        [DataMember]
        public decimal FxAmount;
    }
}
