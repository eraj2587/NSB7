using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Serialization;

namespace WUBS.Contracts.Services.DataContracts
{
    [DataContract]
    [KnownType(typeof (CustomerCreditTransferInitiationContainer))]
    [KnownType(typeof (CustomerDirectDebitInitiationContainer))]
    [KnownType(typeof (CustomerAdviseOfChequeContainter))]
    [XmlInclude(typeof (CustomerCreditTransferInitiationContainer))]
    [XmlInclude(typeof (CustomerDirectDebitInitiationContainer))]
    [XmlInclude(typeof(CustomerAdviseOfChequeContainter))]
    public abstract class PaymentInitiationContainer { }

    [DataContract]
    [XmlRoot("Document", Namespace = "urn:iso:std:iso:20022:tech:xsd:pain.001.001.03")]
    public class CustomerCreditTransferInitiationContainer : PaymentInitiationContainer
    {
        [XmlElement("CstmrCdtTrfInitn")]
        public CustomerCreditTransferInitiation CustomerCreditTransferInitiation;
    }

    [DataContract]
    [XmlRoot("Document", Namespace = "urn:iso:std:iso:20022:tech:xsd:pain.008.001.05")]
    public class CustomerDirectDebitInitiationContainer : PaymentInitiationContainer
    {
        [XmlElement("CstmrDrctDbtInitn")]
        public CustomerDirectDebitInitiation CustomerDirectDebitInitiation;
    }

    [DataContract]
    [XmlRoot(ElementName = "OpaqueRequest", Namespace = "urn:com.travelex:tgbp:gpg:opaque:types")]
    public class CustomerAdviseOfChequeContainter : PaymentInitiationContainer
    {
        [XmlElement("MessageType")]
        public string MessageType;
        [XmlElement("ReceiverBic")]
        public string ReceiverBic;
        [XmlElement("MessagePayload")]
        public XmlNode[] MessagePayload
        {
            get
            {
                var dummy = new XmlDocument();
                return new XmlNode[] { dummy.CreateCDataSection(Content) };
            }
            set
            {
                if (value == null)
                {
                    Content = null;
                    return;
                }
                
                var node0 = value[0];
                var cdata = node0 as XmlCDataSection;
                
                Content = cdata == null? string.Empty : cdata.Data;
            }
        }

        [XmlIgnore]
        public string Content { get; set; }

        [XmlIgnore]
        public CustomerAdviseOfChequeInitiation CustomerChequeInitiation;
    }
}

