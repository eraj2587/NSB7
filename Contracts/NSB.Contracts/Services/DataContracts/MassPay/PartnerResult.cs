using System.Collections.Generic;
using System.Runtime.Serialization;

namespace NSB.Contracts.Services.DataContracts.MassPay
{
    public class PartnerResult
    {
        [DataMember] public IEnumerable<Partner> Partners;
    }
}
