using System.Runtime.Serialization;

namespace WUBS.Contracts.Services.DataContracts.PaymentInstruction
{
    [DataContract]
    public enum PaymentReleaseGateway
    {
        [EnumMember]
        None = 0,
        [EnumMember]
        GpgGateway = 1,
        [EnumMember]
        Apn = 2
    }
}