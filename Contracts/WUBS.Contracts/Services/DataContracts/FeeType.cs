using System.Runtime.Serialization;

namespace WUBS.Contracts.Services.DataContracts
{
    [DataContract]
    public enum FeeType
    {
        [EnumMember]
        PurchaseOfDraft,
        [EnumMember]
        EftToSameCountry,
        [EnumMember]
        EftToForeignCountry
    }
}
