namespace NSB.Contracts.Services.DataContracts.Orders
{
    public class OrderLineItemReference
    {
        public long OrderId { get; set; }
        public int LineItemId { get; set; }
        public string PublicOrderId { get; set; }
        public long ReferencedOrderId { get; set; }
        public int ReferencedLineItemId { get; set; }
        public string ReferencedPublicOrderId { get; set; }
        public byte OrderReferenceType { get; set; }
        public byte LineItemReferenceType { get; set; }
    }
}
