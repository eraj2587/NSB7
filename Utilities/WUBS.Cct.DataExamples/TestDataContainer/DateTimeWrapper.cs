using System;

namespace WUBS.Cct.DataExamples.TestDataContainer
{
    //SQL Server Ce only stores 3 digits of fractional seconds. This means it will truncate enough data 
    // to cause millisecond rounding errors when attempting to re-create a datetime that was saved to 
    // the DB. 
    //This wrapper allows the date time to be saved and restored as a string which contrains full precision
    public struct DateTimeWrapper : IEquatable<DateTimeWrapper>, IEquatable<DateTime>
    {
        private readonly DateTime dateTime;

        public DateTimeWrapper(DateTime dateTime)
        {
            this.dateTime = dateTime;
        }

        public DateTime Date { get { return dateTime.Date; } }

        public override string ToString()
        {
            return dateTime.ToString("o");
            //return "";
        }

        public static DateTimeWrapper Parse(string str)
        {
            return new DateTimeWrapper(DateTime.Parse(str));
        }

        public override bool Equals(Object other)
        {
            if (other == null) return false;
            if (other is DateTimeWrapper)
                if (this.dateTime == ((DateTimeWrapper)other).dateTime)
                    return true;
            if (other is DateTime)
                if (this.dateTime == (DateTime)other)
                    return true;

            return false;
        }

        public bool Equals(DateTime other)
        {
            return dateTime.Equals(other);
        }

        public bool Equals(DateTimeWrapper other)
        {
            return dateTime.Equals(other.dateTime);
        }

        public override int GetHashCode()
        {
            return dateTime.GetHashCode();
        }

        public static implicit operator DateTime(DateTimeWrapper dtWrapper)
        {
            return dtWrapper.dateTime;
        }

        public static implicit operator DateTimeWrapper(DateTime dt)
        {
            return new DateTimeWrapper(dt);
        }

        public static bool operator !=(DateTimeWrapper lhs, DateTimeWrapper rhs)
        {
            return !Equals(lhs, rhs);
        }

        public static bool operator ==(DateTimeWrapper lhs, DateTimeWrapper rhs)
        {
            return Equals(lhs, rhs);
        }

        public DateTimeWrapper AddDays(int numberOfDays)
        {
            return new DateTimeWrapper(this.dateTime.AddDays(numberOfDays));
        }

        public TimeSpan Subtract(DateTime ts)
        {
            return this.dateTime.Subtract(ts);
        }
    }
}