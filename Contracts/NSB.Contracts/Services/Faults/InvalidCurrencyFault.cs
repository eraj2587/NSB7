using System.Runtime.Serialization;

namespace NSB.Contracts.Services.Faults
{
    [DataContract]
    public class InvalidCurrencyFault
    {
         public InvalidCurrencyFault()
            : this("Invalid Currency Fault")
        { }

         public InvalidCurrencyFault(string description)
        {
            ErrorDescription = description;
        }

        [DataMember]
        public string ErrorDescription { get; internal set; }
    }
}
