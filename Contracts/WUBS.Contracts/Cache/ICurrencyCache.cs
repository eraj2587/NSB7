using System.Collections.Generic;
using WUBS.Contracts.Services.DataContracts;

namespace WUBS.Contracts.Cache
{
    public interface ICurrencyCache
    {
        CurrencyDetails GetByCode(string code);

        CurrencyDetails GetById(int id);

        IEnumerable<CurrencyDetails> GetCurrencyList();
    }
}
