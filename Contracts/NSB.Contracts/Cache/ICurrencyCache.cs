using System.Collections.Generic;
using NSB.Contracts.Services.DataContracts;

namespace NSB.Contracts.Cache
{
    public interface ICurrencyCache
    {
        CurrencyDetails GetByCode(string code);

        CurrencyDetails GetById(int id);

        IEnumerable<CurrencyDetails> GetCurrencyList();
    }
}
