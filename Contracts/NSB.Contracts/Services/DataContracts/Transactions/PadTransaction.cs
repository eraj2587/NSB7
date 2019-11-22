using System;
using System.Runtime.Serialization;

namespace NSB.Contracts.Services.DataContracts.Transactions
{
    [DataContract]
    public class PadTransaction
    {
        [DataMember]
        public int OrderId { get; set; }

        [DataMember]
        public string ConfirmationNumber { get; set; }

        [DataMember]
        public int ClientId { get; set; }

        [DataMember]
        public string Account { get; set; }

        [DataMember]
        public int OrderDetailId { get; set; }

        [DataMember]
        public int ItemNumber { get; set; }

        [DataMember]
        public string ClientName { get; set; }

        [DataMember]
        public int OfficeId { get; set; }

        [DataMember]
        public string OfficeCode { get; set; }

        [DataMember]
        public string OfficeDescription { get; set; }

        [DataMember]
        public DateTime Ordered { get; set; }

        [DataMember]
        public DateTime RequestedValueDate { get; set; }

        [DataMember]
        public string TargetCurrencyCode { get; set; }

        [DataMember]
        public decimal TargetAmount { get; set; }

        [DataMember]
        public int ItemTypeId { get; set; }

        [DataMember]
        public string PaymentMethodCode { get; set; }

        [DataMember]
        public string PaymentMethodDescription { get; set; }

        [DataMember]
        public string BeneficiaryName { get; set; }

        [DataMember]
        public string SettlementCurrencyCode { get; set; }

        [DataMember]
        public decimal SettlementAmount { get; set; }

        [DataMember]
        public string ResponsibleUserFirstName { get; set; }

        [DataMember]
        public string ResponsibleUserLastName { get; set; }

        [DataMember]
        public int FundedBy { get; set; }

        [DataMember]
        public int OrderTypeId { get; set; }

        [DataMember]
        public bool IsPredelivery { get; set; }

        [DataMember]
        public bool IsNdf { get; set; }

        [DataMember]
        public string OrderTypeDescription { get; set; }

        [DataMember]
        public WorkflowStatus WorkflowStatus { get; set; }
    }
}