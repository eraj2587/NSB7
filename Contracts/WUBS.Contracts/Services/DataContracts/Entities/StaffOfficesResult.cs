using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WUBS.Contracts.Services.DataContracts.Entities
{
    [DataContract]
    public class StaffOfficesResult
    {
        [DataMember]
        public int DefaultOfficeId;
        [DataMember]
        public List<Office> Offices;
    }
}
