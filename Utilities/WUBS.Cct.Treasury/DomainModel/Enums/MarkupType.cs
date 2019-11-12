using WUBS.Cct.Treasury.DomainModel.Enums.Utility;

namespace WUBS.Cct.Treasury.DomainModel.Enums
{
    public enum MarkupType
    {
        [CctCode("Nostro")]
        Nostro,
        [CctCode("Forward")]
        Forward,
        [CctCode("PreDelivery")]
        Predelivery,        
    }
}
