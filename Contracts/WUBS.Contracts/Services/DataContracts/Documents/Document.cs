using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace WUBS.Contracts.Services.DataContracts
{
    [DataContract]
    public class Document
    {
        [DataMember]
        public long Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Path { get; set; }
        [DataMember]
        public Invoice Invoice { get; set; }
        [DataMember]
        public string Schema { get; set; }
    }

    [DataContract]
    [KnownType(typeof(RepurchaseInvoice))]
    [XmlRoot("Order")]
    public class Invoice
    {
        [DataMember]
        public PrintHeader PrintHeader { get; set; }

        [DataMember]
        public OfficeDetail OfficeDetail { get; set; }

        [DataMember]
        public OrderHeaderDetails OrderHeader { get; set; }

        [DataMember]
        public ClientDetail ClientDetail { get; set; }
        [DataMember]
        [XmlElement("OrderDetail", Type = typeof(OrderDetail))]
        public OrderDetail[] OrderDetail { get; set; }
    }

    [DataContract]
    [XmlRoot("Order")]
    public class RepurchaseInvoice : Invoice
    {
        [DataMember]
        public AmountDueBreakdown AmountDueBreakdown { get; set; }
        [DataMember]
        public OrderDetail[] OriginalOrder { get; set; }
    }

    [Serializable]
    public class PrintHeader
    {

        public string FileCopyConnector;
        public string NotificationMethod;
        public string DateTimeGenerated;

    }

    [Serializable]
    public class OfficeDetail
    {
        [XmlAttribute(AttributeName = "id", DataType = "int")]
        public int Id;

        public string OfficeName;
        public string OfficeAddress;
        public string OfficeEmailFrom;
        public string OfficeEmailReplyTo;
        public string OfficePhone;
        public string OfficeTollFree;
        public string OfficeFax;
        public string OfficeCountry;
        public string RegisteredOffice;
        public string MainOfficeFaxNumber;

    }

    [Serializable]
    public class OrderHeaderDetails
    {
        [XmlAttribute(AttributeName = "number", DataType = "string")]
        public string Number;

        public DateTime OrderDate;
        public DateTime TradeAgreedDate;
        public string OrderType;
        public string ConfirmationNo;
        public string OrderCaptureSystem;
        public string Language;
        public string EntityName;
        public string ShortEntityName;
        public string LicenseNo;
        public string OrderInstructions;
        public string OriginalOrderIdentifier;
    }

    [Serializable]
    public class ClientDetail
    {
        [XmlAttribute(AttributeName = "id", DataType = "int")]
        public int Id;

        public string ClientAccount;
        public string ProcessCenter;
        public string Office;
        public string ClientCategory;
        public string ClientName;
        public string ClientAddressLine1;
        public string ClientAddressLine2;
        public string ClientAddressLine3;
        public string ClientCity;
        public string ClientState;
        public string ClientCounty;
        public string ClientProvince;
        public string ClientPostalCode;
        public string ClientZipCode;
        public string ClientCountry;
        public string ClientEmailAddress;
        public string ClientFaxNumber;
        public string ClientPhoneNumber;
        public string ClientFEIN;
        public string ClientMemo;
        public string InvoiceType;
        public ClientDetailContact Contact;
        public ClientDetailRegistrationAddress RegistrationAddress;
    }

    [Serializable]
    public class ClientDetailContact
    {
        [XmlAttribute(AttributeName = "name")]
        public string Name;

        [XmlAttribute(AttributeName = "type")]
        public string Type;

        public string ContactAddressLine1;
        public string ContactAddressLine2;
        public string ContactAddressLine3;
        public string ContactCity;
        public string ContactState;
        public string ContactCounty;
        public string ContactProvince;
        public string ContactPostalCode;
        public string ContactCountry;
        public string ContactEmailAddress;
        public string ContactFaxNumber;
        public string ContactPhoneNumber;
        public string ContactLanguage;
    }

    [Serializable]
    public class ClientDetailRegistrationAddress
    {
        public string RegistrationAddressSetting;
        public string RegistrationAddressLine1;
        public string RegistrationAddressLine2;
        public string RegistrationAddressLine3;
        public string RegistrationCity;
        public string RegistrationState;
        public string RegistrationCounty;
        public string RegistrationProvince;
        public string RegistrationPostalCode;
        public string RegistrationCountry;
    }

    [Serializable]
    public class OrderDetail
    {
        [XmlAttribute(AttributeName = "ItemNo")]
        public string ItemNo;

        public string ConfirmationNo;
        public int OrderDetail_ID;
        public DateTime OrderDate;
        public string OriginalItemIdentifier;
        public string Product;
        public string Currency;
        public decimal Amount;
        public decimal Rate;
        public int RateIsPer;
        public int Rate_NDec;
        public decimal Fee;
        public decimal Fee_Reporting;
        public decimal OtherFee;
        public decimal OtherFee_Reporting;
        public int RelatedOrderDetail_ID;
        public string RelatedConfirmationNo;
        public int RelatedItemNo;
        public string ItemType_ID;
        public string Currency_ID;
        public string FundedBy;
        public decimal ForeignAmount;
        public decimal ForeignAmountInSC;
        public decimal ForeignAmt_NDec;
        public string OurCheckRef;
        public int Quote_ID;
        public decimal Extension;
        public SettlementDetails SettlementDetails;
        public Beneficiary Beneficiary;

    }

    [Serializable]
    public class SettlementDetails
    {
        public string SettlementCurrency;
        public decimal SettlementAmount;
        public decimal SettlementAmount_NDec;
        public string SettlementMethod;
    }

    [Serializable]
    public class Beneficiary
    {
        [XmlAttribute(AttributeName = "Beneficiary_ID")]
        public string BeneficiaryID;

        public int IsStoredBeneficiary;
        public string BeneName;
    }

    [Serializable]
    [XmlRoot("AmountDue_RepoBreakdown")]
    public class AmountDueBreakdown
    {
        public decimal TotalOutstandingAmount;
        public decimal TotalOutstandingFee;
        public decimal TotalCreditFromRepo;
        public decimal TotalWaivedFees;
        public decimal TotalRepoFees;
        public decimal AmountDue;

    }

}
