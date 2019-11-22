using System;
using System.Runtime.Serialization;

namespace NSB.Contracts.Services.DataContracts.LineItems
{
    [DataContract(Namespace = "http://schemas.business.test.com/2015/10/Opp")]
    public class AgeingHoldingBalanceSearchResult
    {
        [DataMember] public string RegionCode;
        [DataMember] public string ProcessingCenterCode;
        [DataMember] public string OfficeCode;
        [DataMember] public string ResponsibleUser;
        [DataMember] public string Account;
        [DataMember] public string CurrencyCode;
        [DataMember] public Decimal BookBalance;
        [DataMember] public Decimal AvailableBalance;
        [DataMember] public Decimal AgeingBalance;
        [DataMember] public int AgeOfBalance;
        [DataMember] public Decimal OutstandingFees;
        [DataMember] public string Salutation;
        [DataMember] public string FirstName;
        [DataMember] public string LastName;
        [DataMember] public string BusinessName;
        [DataMember] public string AddressLine1;
        [DataMember] public string AddressLine2;
        [DataMember] public string AddressLine3;
        [DataMember] public string City;
        [DataMember] public string StateProvince;
        [DataMember] public string ZipPostalCode;
        [DataMember] public string Country;
        [DataMember] public string Phone;
    }
}
