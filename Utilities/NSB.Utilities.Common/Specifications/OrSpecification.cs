
namespace NSB.Utilities.Common.Specifications
{
    public class OrSpecification<T> : CompositeSpecification<T>
    {
        public OrSpecification(ISpecification<T> left, ISpecification<T> right)
            : base(left, right)
        {
        }

        public override bool IsSatisfiedBy(T candidate)
        {
            return left.IsSatisfiedBy(candidate) || right.IsSatisfiedBy(candidate);
        }
    }
}
