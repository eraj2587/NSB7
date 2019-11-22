using System.Runtime.Serialization;

namespace NSB.Contracts.Services.DataContracts.CustomerContracts
{
    public class SearchCustomerResponse
    {
        [DataMember]
        public int CustomerId { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public string City { get; set; }

        /// <summary>
        /// HATEOAS
        /// </summary>
        [DataMember]
        public string HRef { get; set; }
    }
}
