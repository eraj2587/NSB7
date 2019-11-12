using System;
using WUBS.Cct.Treasury.DomainModel.Vms;

namespace WUBS.Cct.Treasury.DomainModel.Entities
{
    public class FuturePaymentEventLog
    {
        public int Id { get; set; }
        public int LineItemId { get; set; }
        public DateTime NewReleaseDate { get; set; }
        public RecordStatus Status { get; set; }
        public DateTime? ProcessedTime { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public DateTime? PreviousReleaseDate { get; set; }
    }
}