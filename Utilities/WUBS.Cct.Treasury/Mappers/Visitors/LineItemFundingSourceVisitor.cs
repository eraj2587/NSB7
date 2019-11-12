using WUBS.Cct.Treasury.DomainModel.Entities;
using WUBS.Cct.Treasury.Mappers.Factories;

namespace WUBS.Cct.Treasury.Mappers.Visitors
{
    public class LineItemFundingSourceVisitor : LineItemVisitor
    {
        private readonly IFundingSourceFactory fundingSourceFactory;

        public LineItemFundingSourceVisitor(IFundingSourceFactory fundingSourceFactory)
        {
            this.fundingSourceFactory = fundingSourceFactory;
        }

        public override void Visit(LineItem lineItem)
        {
            lineItem.FundingSource = fundingSourceFactory.Create(lineItem);
        }
    }
}
