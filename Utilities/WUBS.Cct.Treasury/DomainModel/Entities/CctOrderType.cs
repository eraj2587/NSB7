using System.Runtime.Serialization;

namespace WUBS.Cct.Treasury.DomainModel.Entities
{
    [DataContract]
    public class CctOrderType
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Code { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public int BuySellId { get; set; }

        [DataMember]
        public int SpreadTypeId { get; set; }
    }

    [DataContract]
    public class CctRepurchaseType
    {
        [DataMember]
        public int RepoOrderTypeId { get; set; }
        [DataMember]
        public int OrderTypeId { get; set; }
        [DataMember]
        public string Code { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public int BuySellId { get; set; }
        [DataMember]
        public int SpreadTypeId { get; set; }
    }
}
