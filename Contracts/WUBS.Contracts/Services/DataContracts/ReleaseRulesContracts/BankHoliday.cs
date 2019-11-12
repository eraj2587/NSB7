using System;
using System.Runtime.Serialization;

namespace WUBS.Contracts.Services.DataContracts.ReleaseRulesContracts
{
    [DataContract]
    public class BankHoliday
    {
        [DataMember]
        public int BankHolidayId { get; set; }
        [DataMember]
        public string CurrencyCode { get; set; }
        [DataMember]
        public string CountryCode { get; set; }
        [DataMember]
        public DateTime? HolidayDate { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public DateTime? CreatedDate { get; set; }
        [DataMember]
        public int? CreatedBy { get; set; }
        [DataMember]
        public DateTime? UpdatedDate { get; set; }
        [DataMember]
        public int? UpdatedBy { get; set; }
    }
}
