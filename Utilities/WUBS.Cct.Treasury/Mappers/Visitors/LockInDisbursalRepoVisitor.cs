using System;
using System.Collections.Generic;
using System.Linq;
using WUBS.Cct.Treasury.DomainModel.Entities;
using WUBS.Cct.Treasury.DomainModel.Enums;
using WUBS.Cct.Treasury.Exceptions;
using WUBS.Cct.Treasury.Infrastructure.Utilities;

namespace WUBS.Cct.Treasury.Mappers.Visitors
{
    public class LockInDisbursalRepoVisitor : OrderVisitor
    {
        public override void Visit(Order order)
        {
            if (order.OrderType != OrderType.LockInDisbursalOrderRepurchase)
                return;

            var lockinDisbursalRepo = order as LinkedOrder;

            if (lockinDisbursalRepo == null)
                throw new ArgumentException("LockInDisbursalOrderRepurchase is not a valid linked order.");

            lockinDisbursalRepo.LineItems
                .GroupBy(li => li.TradeMoney.Currency)
                .Where(lineItems => !AllLineItemsHaveFundingSource(lineItems))
                .ForEach(SetFundingSource);
        }

        private bool AllLineItemsHaveFundingSource(IEnumerable<LineItem> lineItems)
        {
            return lineItems.All(li => li.FundingSource != null);
        }

        public void SetFundingSource(IEnumerable<LineItem> lineItems)
        {
            var fundingSource = lineItems.Where(li => li.FundingSource != null).Select(li => li.FundingSource).FirstOrDefault();

            if (fundingSource == null)
                throw new InvalidFundingSourceException("No valid funding source for lockin disbursal repurchase line items.");

            lineItems.ForEach(li => li.FundingSource = fundingSource);
        }
    }
}
