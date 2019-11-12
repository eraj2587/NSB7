using System.Collections.Generic;

namespace WUBS.Cct.Treasury.Mappers.Interfaces
{
    public interface ILineItemToContractMapper
    {
        long GetContractId(int lineItemId);
        void Save(LineItemToContractMapping mapping);
        void Update(int newLineItemId, int existingLineItemId);
        IList<int> GetLineItemIdsByContractIds(long[] contractIds);
        IList<long> GetContractIdsByLineItemIds(int[] lineItemIds);
        IList<int> GetLineItemIdsByRelatedLineItemIds(int[] lineItemIds);
        bool IsAggregatedContract(long contractId, int[] lineItemIds);
        void DisableLineItemToContractMappings(int lineItemId);
    }
}
