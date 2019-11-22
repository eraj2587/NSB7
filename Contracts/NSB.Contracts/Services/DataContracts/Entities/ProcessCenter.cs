using System;
using System.Runtime.Serialization;

namespace NSB.Contracts.Services.DataContracts
{
    [DataContract]
    public class ProcessCenter : IComparable
    {
        [DataMember]
        public string Code { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int? RegionId { get; set; }
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

        public static bool operator !=(ProcessCenter one, ProcessCenter another)
        {
            return !(one == another);
        }

        public static implicit operator string(ProcessCenter processCenter)
        {
            return processCenter == null ? null : processCenter.ToString();
        }

        public static bool operator ==(ProcessCenter one, ProcessCenter another)
        {
            if ((object)one == null)
            {
                return (object)another == null;
            }

            return one.Equals(another);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is ProcessCenter))
            {
                return false;
            }

            return Code == ((ProcessCenter)obj).Code;
        }
    }
}
