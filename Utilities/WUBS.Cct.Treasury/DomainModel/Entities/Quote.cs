using System;
using WUBS.Cct.Treasury.DomainModel.Enums;

namespace WUBS.Cct.Treasury.DomainModel.Entities
{
    [Serializable]
    public abstract class Quote
    {
        public int Id { get; set; }
        
        public int RateRunId { get; set; }

        public DateTime ExpirationTimeStamp { get; set; }
        public double ExpirationDurationInMinutes { get; set; }

        public decimal EffectiveMultiplier { get; set; }
        public MarkupType MarkupType { get; set; }
        public int ClientId { get; set; }
    }
}
