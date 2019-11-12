using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Security.Claims;

namespace WUBS.Contracts.Services.DataContracts.Authentication
{
    [DataContract(Namespace = "http://schema.business.westernunion.com/contracts/authentication")]
    public class Token
    {
        [DataMember]
        public IEnumerable<Claim> Claims { get; set; }
    }

    public static class CustomClaimTypes
    {
        public static string CctUserId = "http://schema.business.westernunion.com/claims/cctuserid";
        public static string Task = "http://schema.business.westernunion.com/claims/task";
        public static string BookingSource = "http://schema.business.westernunion.com/claims/bookingsource";
        public static string ExternalSystem = "http://schema.business.westernunion.com/claims/externalsystem";
    }
}