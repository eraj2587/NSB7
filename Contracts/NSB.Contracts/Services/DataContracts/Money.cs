using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace NSB.Contracts.Services.DataContracts
{
    [DataContract]
    [Serializable]
    public class Money
    {
        public static readonly Money Null = new Money(null, 0m);

        public Money() { }

        [JsonConstructor]
        public Money(Currency currency, decimal amount)
        {
            Amount = amount;
            Currency = currency ?? Currency.Null;
        }

        [DataMember]
        public Currency Currency { get; set; }

        [DataMember]
        public decimal Amount { get; set; }


        public override string ToString()
        {
            return string.Format("{0} {1}", Currency.Code, Amount);
        }
    }

}
