using System;
using WUBS.Cct.Treasury.DomainModel.Enums;
using WUBS.Cct.Treasury.DomainModel.Financial;

namespace WUBS.Cct.Treasury.DomainModel.Entities
{
    [Serializable]
    public class SingleSidedLineItem : LineItem
    {
        public int? BeneficiaryId { get; set; }
        public string BankListCode { get; set; }
        public DateTime? DepositDueDate { get; set; }
    }
}
