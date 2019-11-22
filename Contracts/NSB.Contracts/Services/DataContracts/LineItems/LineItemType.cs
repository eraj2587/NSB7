using System.Runtime.Serialization;

namespace NSB.Contracts.Services.DataContracts.LineItems
{
    [DataContract(Namespace = "http://schemas.business.test.com/2015/10/Opp")]
    public enum LineItemType
    {
        [EnumMember]
        HoldingTransfer,
        
        [EnumMember]
        HoldingTransferRepurchase
    }
}