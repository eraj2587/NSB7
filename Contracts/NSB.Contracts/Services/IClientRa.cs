using System.Runtime.Serialization;
using System.ServiceModel;
using WUBS.Contracts.Services.Faults;

namespace WUBS.Contracts.Services
{
    [ServiceContract]
    public interface IClientRa
    {
        [OperationContract]
        [FaultContract(typeof(InvalidCustomerFault))]
        Client GetClient(string account);

    }

    [DataContract]
    public class Client
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Account { get; set; }

        [DataMember]
        public string Code { get; set; }

        [DataMember]
        public int OfficeId { get; set; }
    }
}
