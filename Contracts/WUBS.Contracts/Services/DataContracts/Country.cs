using System.ComponentModel;
using System.Runtime.Serialization;

namespace WUBS.Contracts.Services.DataContracts
{
    [DataContract]
    public class Country
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        [Description("2-letter ISO code")]
        public string Code { get; set; }  

        [DataMember]
        [Description("3-letter ISO code")]
        public string Alpha3 { get; set; }

        [DataMember]
        public string Description { get; set; }
    }
}
