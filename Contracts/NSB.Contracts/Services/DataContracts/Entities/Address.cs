using System.Runtime.Serialization;

namespace NSB.Contracts.Services.DataContracts
{
    [DataContract]
    public class Address
    {
        [DataMember]
        public string StreetAddress1 { get; set; }

        [DataMember]
        public string StreetAddress2 { get; set; }

        [DataMember]
        public string StreetAddress3 { get; set; }

        [DataMember]
        public string City { get; set; }

        [DataMember]
        public virtual string StateProvince { get; set; }

        [DataMember]
        public string ZipPostalCode { get; set; }

        [DataMember]
        public Country Country { get; set; }
    }

    //Adding New Class for Client Address for displaying separate State and province
    [DataContract]
    public class ClientAddress:Address
    {
        [DataMember(Name = "State")]
        public override string StateProvince { get; set; }        
        [DataMember]
        public string Province { get; set; }
     
    }
}
