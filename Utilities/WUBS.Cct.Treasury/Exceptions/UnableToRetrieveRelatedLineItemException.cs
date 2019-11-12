using System;
using WUBS.Cct.Treasury.DomainModel.Entities;

namespace WUBS.Cct.Treasury.Exceptions
{
    public class UnableToRetrieveRelatedLineItemException : Exception
    {
        private readonly LineItem lineItem;

        public UnableToRetrieveRelatedLineItemException(LineItem lineItem, string message)
            : base(message)
        {
            this.lineItem = lineItem;
        }

        public UnableToRetrieveRelatedLineItemException(LineItem lineItem)
            : base(string.Format("Unable to get related lineitem for lineItem id {0}.", lineItem.Id))
        {
            this.lineItem = lineItem;
        }
    }
}
