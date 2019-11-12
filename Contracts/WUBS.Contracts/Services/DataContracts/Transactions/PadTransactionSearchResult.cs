using System.Collections.Generic;

namespace WUBS.Contracts.Services.DataContracts.Transactions
{
    public class PadTransactionSearchResult
    {
        public int TotalCount { get; set; }
        public IEnumerable<PadTransaction> PagedItems { get; set; }
        public string ErrorMsg { get; set; }
        public bool NoResultsBecauseOfOfficePermissions { get; set; }
        public string NameOfDeniedOffice { get; set; }
    }
}
