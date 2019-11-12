using System.Runtime.Serialization;

namespace WUBS.Contracts.Services.DataContracts
{
    public enum SettingType
    {
        Integer,
        Float,
        DateTime,
        Char,
        Flag,
        PickList
    }

    public enum Entity
    {
        User,
        Client,
        Office,
        ProcessingCenter,
        Application,
        Beneficiary,
        EnterpriseGroup
    }

    public enum Application
    {
        GlobalPay,
        GlobalPayPlus,
        Compliance = 70,
        Eft,
        LO,
        OpsEss,
        MassPay = 134
    }

    [DataContract]
    public class Setting
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public SettingType Type { get; set; }

        [DataMember]
        public string Code { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public int PickListId { get; set; }
    }
}
