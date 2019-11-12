using System;
using WUBS.Cct.Treasury.DomainModel.Enums;
using WUBS.Cct.Treasury.DomainModel.Financial;
using WUBS.Cct.Treasury.DomainModel.FundingSource;

namespace WUBS.Cct.Treasury.DomainModel.Entities
{
    [Serializable]
    public class LineItem
    {
        public int Id { get; set; }
        public int? RelatedLineItemId { get; set; }
        public long ContractId { get; set; }
        public int Number { get; set; }

        public Money TradeMoney { get; set; }
        public Money SettlementMoney { get; set; }
        public bool IsAmountInSettlementCurrency { get; set; }
        public int TradeAmountNDec { get; set; }

        public decimal ItemRateValue { get; set; }
        public ItemType LineItemType { get; set; }

        public int QuoteId { get; set; }
        public LineItemFundingMethod LineItemFundingMethod { get; set; }
        public LineItemFundingSource FundingSource { get; set; }
        public int ContributingItemId { get; set; }
        
        public DateTime? ValueDate { get; set; }
        
        public int WindowLength { get; set; }

        public string OptionContractId { get; set; }

        public int? OptionLeg { get; set; }

        public DateTime? WindowStartDate { get; set; }

        public DateTime? WindowEndDate 
        {
            get { return WindowStartDate.HasValue 
                ? WindowStartDate.Value.AddDays(WindowLength)
                : (DateTime?)null; } 
        }

        public bool SameCurrencyTrade()
        {
            return TradeMoney.Currency == SettlementMoney.Currency;
        }

        public bool IsQuotedSeparatelyFrom(LineItem lineItem)
        {
            return FundingSource.IsQuoted && lineItem.FundingSource.QuoteId != FundingSource.QuoteId;
        }

        public bool IsReverseOf(LineItem lineItem)
        {
            return LineItemType == ItemType.LockInSaleAdjustment && 
                TradeMoney.Currency == lineItem.TradeMoney.Currency &&
                TradeMoney.Amount + lineItem.TradeMoney.Amount == 0;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public bool IsPartOfAggregation(Order order)
        {
            return order.LineItems.Exists(l => l.ContractId == ContractId && l.Id != Id);
        }

        public override string ToString()
        {
            return Id.ToString();
        }

        public LineItem SetOpenValueDate(LineItem lineItem)
        {
            WindowStartDate = lineItem.WindowStartDate;
            WindowLength = lineItem.WindowLength;

            return this;
        }

        public void SwapTradeAndSettlementMoney()
        {
            var newSettlementMoney = TradeMoney;
            TradeMoney = SettlementMoney;
            SettlementMoney = newSettlementMoney;
        }

        public bool TradeAndSettlementAmountsAreZero()
        {
            return TradeMoney.Amount == 0 && SettlementMoney.Amount == 0;
        }
    }
}
