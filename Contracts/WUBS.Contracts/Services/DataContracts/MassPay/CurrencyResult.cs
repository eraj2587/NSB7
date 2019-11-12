using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WUBS.Contracts.Services.DataContracts.MassPay
{
    public class CurrencyResult
    {
        [DataMember]
        public IEnumerable<CurrencyDetails> Currencies;
    }
}
