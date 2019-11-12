namespace WUBS.Cct.Treasury.Mappers
{
    public class LineItemToContractMapping
    {
        public LineItemToContractMapping(int lineItemId, long contractId)
        {
            LineItemId = lineItemId;
            ContractId = contractId;
        }

        public int LineItemId { get; private set; }
        public long ContractId { get; private set; }
    }
}
