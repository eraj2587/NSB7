using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using WUBS.Contracts.Services.Faults;

namespace WUBS.Contracts.Services
{
    [ServiceContract]
    public interface ICurrencyRa
    {
        [OperationContract]
        [FaultContract(typeof(InvalidCurrencyFault))]
        Currency GetByCode(string code);

        [OperationContract]
        [FaultContract(typeof(InvalidCurrencyFault))]
        Currency GetById(int id);

        [OperationContract]
        IEnumerable<Currency> GetCurrenciesForConsignment();

        //[OperationContract]
        //IEnumerable<Currency> GetCurrenciesByCapability(CurrencyCapability capability);

    }

    [DataContract]
    public class Currency
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Code { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public int NumberOfDecimals { get; set; }
        [DataMember]
        public decimal RoundToNearestValue { get; set; }
        [DataMember]
        public decimal MinimumTransactionAmount { get; set; }
        [DataMember]
        public decimal MaximumTransactionAmount { get; set; }

    }
}
