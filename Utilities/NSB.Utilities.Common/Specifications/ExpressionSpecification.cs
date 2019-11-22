
using System;

namespace NSB.Utilities.Common.Specifications
{
    public class ExpressionSpecification<T> : Specification<T>
    {
        private Func<T, bool> expression;
        public ExpressionSpecification(Func<T, bool> expression)
        {
            if (expression == null)
                throw new ArgumentNullException();
            
            this.expression = expression;
        }

        public override bool IsSatisfiedBy(T o)
        {
            return expression(o);
        }
    }  
}
