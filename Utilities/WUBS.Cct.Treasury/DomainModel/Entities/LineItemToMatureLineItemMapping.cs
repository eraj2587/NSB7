
namespace WUBS.Cct.Treasury.DomainModel.Entities
{
    public class LineItemToMatureLineItemMapping
    {
        public int OriginalLineItemId { get; set; }

        public int RelatedMatureOrderLineItemId { get; set; }
    }
}
