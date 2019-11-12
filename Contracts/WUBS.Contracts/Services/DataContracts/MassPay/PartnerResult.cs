using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WUBS.Contracts.Services.DataContracts.MassPay
{
    public class PartnerResult
    {
        [DataMember] public IEnumerable<Partner> Partners;
    }
}
