using System.Runtime.Serialization;

namespace NSB.Contracts.Services.DataContracts
{
    [DataContract]
    public enum  ReasonForTransaction
    {
        [EnumMember]
        None,
        [EnumMember]
        AdvertisingFees,
        [EnumMember]
        ExpenseReimbursement,
        [EnumMember]
        FinancialServices,
        [EnumMember]
        LegalServices,
        [EnumMember]
        MedicalReimbursement,
        [EnumMember]
        Other,
        [EnumMember]
        Payroll,
        [EnumMember]
        Processing,
        [EnumMember]
        TradeRelatedServices,
        [EnumMember]
        TransactionBetweenBanks,
        [EnumMember]
        TransportationCost,
        [EnumMember]
        TravelRelatedServices
    }
}