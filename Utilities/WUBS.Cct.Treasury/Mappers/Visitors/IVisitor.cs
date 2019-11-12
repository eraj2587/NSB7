namespace WUBS.Cct.Treasury.Mappers.Visitors
{
    interface IVisitor<in T>
    {
        void Visit(T element);
    }
}
