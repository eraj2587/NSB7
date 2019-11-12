
namespace WUBS.Utilities.Common.Specifications
{
    public class NotSpecification<T> : Specification<T>
    {
        private readonly ISpecification<T> specification;

        public NotSpecification(ISpecification<T> specification)
        {
            this.specification = specification;
        }

        public override bool IsSatisfiedBy(T candidate)
        {
            return !specification.IsSatisfiedBy(candidate);
        }
    }
}
