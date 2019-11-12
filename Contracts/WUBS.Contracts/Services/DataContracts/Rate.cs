using System.Runtime.Serialization;

namespace WUBS.Contracts.Services.DataContracts
{
    [DataContract]
    public class Rate
    {

        [DataMember]
        public decimal Value { get; set; }

        [DataMember]
        public Currency UnitCurrency { get; set; }

        [DataMember]
        public Currency RefCurrency { get; set; }

        [DataMember]
        public int NumDecimals { get; set; }

        [DataMember]
        public bool IsDirect { get; set; }

        public Rate()
        {
        }

        public Rate(decimal value, Currency unitCurrency, Currency refCurrency, int numDecimals, bool isDirect)
        {
            Value = value;
            UnitCurrency = unitCurrency ?? Currency.Null;
            RefCurrency = refCurrency ?? Currency.Null;
            NumDecimals = numDecimals;
            IsDirect = isDirect;
        }

        public override string ToString()
        {
            return string.Format("{0}{1} {2} {3}", UnitCurrency, RefCurrency, Value, IsDirect ? "dir" : "ind");
        }
    }
}
