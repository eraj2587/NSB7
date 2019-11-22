using System;
using System.Runtime.Serialization;

namespace NSB.Contracts.Services.DataContracts
{
    [DataContract]
    public class Office : IComparable
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Code { get; set; }
        [DataMember]
        public string PaymentCode { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public int ProcessCenterId { get; set; }
        [DataMember]
        public int? DefaultSettlementCurrency_ID{ get; set; }

        public int CompareTo(object obj)
        {
            return Code.CompareTo(obj.ToString());
        }

        public override string ToString()
        {
            return Code.ToString();
        }

        public override int GetHashCode()
        {
            return Code.GetHashCode();
        }

        public static bool operator !=(Office one, Office another)
        {
            return !(one == another);
        }

        public static implicit operator string(Office processCenter)
        {
            return processCenter == null ? null : processCenter.ToString();
        }

        public static bool operator ==(Office one, Office another)
        {
            if ((object)one == null)
            {
                return (object)another == null;
            }

            return one.Equals(another);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Office))
            {
                return false;
            }

            return Code == ((Office)obj).Code;
        }
    }
}
