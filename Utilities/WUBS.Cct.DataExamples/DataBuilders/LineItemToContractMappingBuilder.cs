using System;
using WUBS.Cct.DataExamples.TestDataContainer;

namespace WUBS.Cct.DataExamples.DataBuilders
{
    internal class LineItemToContractMappingBuilder<T>
        where T : StaticDataRow, new()
    {
        private int lineItemId = 1;
        private long contractId = 1;
        private bool isActive = true;
        private int id;

        public LineItemToContractMappingBuilder()
        {
            if (typeof(T) != typeof(RueschlinkDB.LineItemToContractMapping.LineItemToContractMappingRow))
                throw new InvalidOperationException(string.Format("Generic type T ({0}) is not supported by this builder", typeof(T).Name));
        }

        public T Build()
        {
            dynamic row = new T();
            row.LineItemId = lineItemId;
            row.ContractId = contractId;
            row.IsActive = isActive;
            row.Id = id;
            return row;
        }

        public LineItemToContractMappingBuilder<T> WithLineItemId(int lineItemId)
        {
            this.lineItemId = lineItemId;
            return this;
        }

        public LineItemToContractMappingBuilder<T> WithContractId(long contractId)
        {
            this.contractId = contractId;
            return this;
        }

        public LineItemToContractMappingBuilder<T> IsActive(bool isActive)
        {
            this.isActive = isActive;
            return this;
        }

        public LineItemToContractMappingBuilder<T> WithId(int id)
        {
            this.id = id;
            return this;
        }
    }
}