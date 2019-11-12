using System.Runtime.Serialization;

namespace WUBS.Contracts.Services.Faults
{
    [DataContract]
        public class UnableToTransferOrderToFinanceFault
        {
            public UnableToTransferOrderToFinanceFault()
                : this("Unable to Transfer order to Finance fault")
            { }

            public UnableToTransferOrderToFinanceFault(string description)
            {
                ErrorDescription = description;
            }

            [DataMember]
            public string ErrorDescription { get; internal set; }
        }
}
