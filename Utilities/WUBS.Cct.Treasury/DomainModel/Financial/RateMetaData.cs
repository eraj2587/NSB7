using System;

namespace WUBS.Cct.Treasury.DomainModel.Financial
{
    [Serializable]
    public struct RateMetaData : IEquatable<RateMetaData>
    {
        private const int numberOfDecimalsIndirectUnmultiplied = 12;
        private int numberOfDecimalsDirectMultiplied;
        private int numberOfDecimalsIndirectMultiplied;
        private const int numberOfDecimalsDirectUnmultiplied = 12;
        private int multiplierDirect;
        private int multiplierIndirect;

        public int NumberOfDecimalsDirectMultiplied
        {
            get { return numberOfDecimalsDirectMultiplied; }
            set { numberOfDecimalsDirectMultiplied = value; }
        }

        public int NumberOfDecimalsIndirectMultiplied
        {
            get { return numberOfDecimalsIndirectMultiplied; }
            set { numberOfDecimalsIndirectMultiplied = value; }
        }

        public int NumberOfDecimalsDirectUnmultiplied
        {
            get { return numberOfDecimalsDirectUnmultiplied; }
        }

        public int NumberOfDecimalsIndirectUnmultiplied
        {
            get { return numberOfDecimalsIndirectUnmultiplied; }
        }

        public int MultiplierDirect
        {
            get { return multiplierDirect; }
            set { multiplierDirect = value; }
        }

        public int MultiplierIndirect
        {
            get { return multiplierIndirect; }
            set { multiplierIndirect = value; }
        }

        public RateMetaData(int numberOfDecimalsDirectMultiplied, int numberOfDecimalsIndirectMultiplied, int multiplierDirect, int multiplierIndirect) : this()
        {
            if (multiplierDirect == 0 || multiplierIndirect == 0)
                throw new ArgumentException("Rate multipliers must be greater than 0.");

            if (numberOfDecimalsDirectMultiplied < 0 || numberOfDecimalsIndirectMultiplied < 0)
                throw new ArgumentException("Precision must be greater than 0.");

            this.numberOfDecimalsDirectMultiplied = numberOfDecimalsDirectMultiplied;
            this.numberOfDecimalsIndirectMultiplied = numberOfDecimalsIndirectMultiplied;
            this.multiplierDirect = multiplierDirect;
            this.multiplierIndirect = multiplierIndirect;
        }

        public bool Equals(RateMetaData other)
        {
            return numberOfDecimalsDirectMultiplied == other.numberOfDecimalsDirectMultiplied && numberOfDecimalsIndirectMultiplied == other.numberOfDecimalsIndirectMultiplied && multiplierDirect == other.multiplierDirect && multiplierIndirect == other.multiplierIndirect;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is RateMetaData && Equals((RateMetaData)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = numberOfDecimalsDirectMultiplied;
                hashCode = (hashCode * 397) ^ numberOfDecimalsIndirectMultiplied;
                hashCode = (hashCode * 397) ^ multiplierDirect;
                hashCode = (hashCode * 397) ^ multiplierIndirect;
                return hashCode;
            }
        }

        public static bool operator ==(RateMetaData left, RateMetaData right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(RateMetaData left, RateMetaData right)
        {
            return !left.Equals(right);
        }
    }
}
