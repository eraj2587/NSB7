using System;

namespace WUBS.Cct.Treasury.DomainModel.Vms
{
    public class VmsEventLog
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int LineItemId { get; set; }
        public int? NewOrderId { get; set; }
        public int? NewLineItemId { get; set; }
        public int? ItemNumber { get; set; }
        public string Event { get; set; }
        public RecordStatus Status { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public class VmsEvent
        {
            public const string Modified = "MODIFY";
            public const string Splitted = "SPLIT";
            public const string Cancelled = "CANCEL";
        }
    }
}
