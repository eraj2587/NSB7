
namespace NSB.Utilities.Common.Specifications
{
    public abstract class CompositeSpecification<T> : Specification<T>
    {
        protected readonly ISpecification<T> left;
        protected readonly ISpecification<T> right;

        protected CompositeSpecification(ISpecification<T> left, ISpecification<T> right)
        {
            this.left = left;
            this.right = right;
        }
    }
}
