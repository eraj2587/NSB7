
namespace WUBS.Utilities.Common.Specifications
{
    public class AndSpecification<T> : CompositeSpecification<T>
    {
        public AndSpecification(ISpecification<T> left, ISpecification<T> right)
            : base(left, right)
        {
        }

        public override bool IsSatisfiedBy(T candidate)
        {
            return left.IsSatisfiedBy(candidate) && right.IsSatisfiedBy(candidate);
        }
    }
}
