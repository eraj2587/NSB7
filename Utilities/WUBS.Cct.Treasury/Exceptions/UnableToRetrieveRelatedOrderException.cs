using System;
using WUBS.Cct.Treasury.DomainModel.Entities;

namespace WUBS.Cct.Treasury.Exceptions
{
    public class UnableToRetrieveRelatedOrderException : Exception
    {
        private readonly Order order;

        public UnableToRetrieveRelatedOrderException(Order order, string message)
            : base(message)
        {
            this.order = order;
        }

        public UnableToRetrieveRelatedOrderException(Order order)
            : base(string.Format("Unable to get related order for order id {0}.", order.Id))
        {
            this.order = order;
        }
    }
}
