using System.Runtime.Serialization;

namespace NSB.Contracts.Services.DataContracts
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
