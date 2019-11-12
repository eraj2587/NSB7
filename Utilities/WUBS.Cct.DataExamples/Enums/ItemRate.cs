namespace WUBS.Cct.DataExamples.Enums
{
    public class ItemRate
    {
        public short? InvRateMultiplier { get; private set; }
        public decimal RateValue { get; private set; }
        public short IsPer { get; private set; }
        public int? NDec { get; private set; }
        public int RateMultiplier { get; set; }

        public ItemRate(decimal rateValue, short isPer, int? nDec, int rateMultiplier, short? invRateMultiplier)
        {
            this.InvRateMultiplier = invRateMultiplier;
            this.RateValue = rateValue;
            this.IsPer = isPer;
            this.NDec = nDec;
            this.RateMultiplier = rateMultiplier;
        }
    }
}