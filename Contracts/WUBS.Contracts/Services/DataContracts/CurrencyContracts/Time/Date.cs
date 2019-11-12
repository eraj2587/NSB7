using Newtonsoft.Json;
using System;
using System.Globalization;

namespace WUBS.Contracts.Services.DataContracts.CurrencyContracts.Time
{
    class DateConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, ((Date)value).ToDateTime());
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return existingValue;
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof(Date).IsAssignableFrom(objectType);
        }
    }


    [Serializable]
    [JsonConverter(typeof(DateConverter))]
	public struct Date : IConvertible
	{
		[JsonProperty]
		private DateTime date;
		public static Date MinValue = new Date(DateTime.MinValue);
		public static Date MaxValue = new Date(DateTime.MaxValue);
		public static Date Null = MinValue;

        [JsonConstructor]
		public Date(DateTime time)
		{
			date = time.Date;
		}
		
		public Date(int year, int month, int day) : this(new DateTime(year, month, day))
		{
		}

		public static Date Today
		{
			get { return new Date(DateTime.UtcNow); }	
		}

		public Date AddDays(int days)
		{
			return new Date(date.AddDays(days));
		}

		public Date AddMonths(int months)
		{
			return new Date(date.AddMonths(months));
		}

		public Date SubtractDays(int days)
		{
			return AddDays(-days);
		}

		public bool FallsWithin(DateRange range)
		{
			return range.Contains(this);
		}

		public DayOfWeek DayOfWeek
		{
			get { return date.DayOfWeek; }
		}

		public int Year
		{
			get { return date.Year; }
		}
		
		public int Month
		{
			get { return date.Month; }
		}
		
		public int Day
		{
			get { return date.Day; }
		}

		public DateTime BreachEncapsulationOfDateTime()
		{
			return date;
		}

		static public bool operator == (Date date1, Date date2)
		{
			return date1.Equals(date2);
		}

		static public bool operator != (Date date1, Date date2)
		{
			return !(date1 == date2);
		}

		static public bool operator < (Date date1, Date date2)
		{
			return date1.date < date2.date;
		}

		static public bool operator > (Date date1, Date date2)
		{
			return date1.date > date2.date;
		}

		static public bool operator <= (Date date1, Date date2)
		{
			return !(date1.date > date2.date);
		}

		static public bool operator >= (Date date1, Date date2)
		{
			return !(date1.date < date2.date);
		}

		public override bool Equals(object obj)
		{
			if( !(obj is Date) )
				return false;
			
			return date == ((Date)obj).date;
		}

		public override int GetHashCode()
		{
			return date.GetHashCode();
		}

		public Date SkipWeekends()
		{
			switch (date.DayOfWeek)
			{
				case DayOfWeek.Saturday:
					return AddDays(2);

				case DayOfWeek.Sunday:
					return AddDays(1);
			}
			return this;
		}

		public DateTime ToDateTime()
        {
            return date;
        }
        
        #region IConvertible Members

		public sbyte ToSByte(IFormatProvider provider)
		{
			return ((IConvertible) date).ToSByte(provider);
		}

		public double ToDouble(IFormatProvider provider)
		{
			return ((IConvertible) date).ToDouble(provider);
		}

		public DateTime ToDateTime(IFormatProvider provider)
		{
			return date;
		}

		public float ToSingle(IFormatProvider provider)
		{
			return ((IConvertible) date).ToSingle(provider);
		}

		public bool ToBoolean(IFormatProvider provider)
		{
			return ((IConvertible) date).ToBoolean(provider);
		}

		public int ToInt32(IFormatProvider provider)
		{
			return ((IConvertible) date).ToInt32(provider);
		}

		public ushort ToUInt16(IFormatProvider provider)
		{
			return ((IConvertible) date).ToUInt16(provider);
		}

		public short ToInt16(IFormatProvider provider)
		{
			return ((IConvertible) date).ToInt16(provider);
		}

		public string ToString(IFormatProvider provider)
		{
		    DateTimeFormatInfo dateTimeFormatInfo = provider as DateTimeFormatInfo;

            if (dateTimeFormatInfo == null)
                return ToString();

			return date.ToString(dateTimeFormatInfo.LongDatePattern);
		}

		public override string ToString()
		{
			return date.ToShortDateString();
		}

		public byte ToByte(IFormatProvider provider)
		{
			return ((IConvertible) date).ToByte(provider);
		}

		public char ToChar(IFormatProvider provider)
		{
			return ((IConvertible) date).ToChar(provider);
		}

		public long ToInt64(IFormatProvider provider)
		{
			return ((IConvertible) date).ToInt64(provider);
		}

		public ulong ToUInt64(IFormatProvider provider)
		{
			return ((IConvertible) date).ToUInt64(provider);
		}

		public TypeCode GetTypeCode()
		{
			return  date.GetTypeCode();
		}

		public decimal ToDecimal(IFormatProvider provider)
		{
			return ((IConvertible) date).ToDecimal(provider);
		}

		public object ToType(Type conversionType, IFormatProvider provider)
		{
			return ((IConvertible) date).ToType(conversionType, provider);
		}

		public uint ToUInt32(IFormatProvider provider)
		{
			return ((IConvertible) date).ToUInt32(provider);
		}

		#endregion

        public static implicit operator DateTime(Date d)
        {
            return d.ToDateTime();
        }

        public static explicit operator Date(DateTime d)
        {
            return new Date(d);
        }

		public static Date LatestOf(Date date1, Date date2)
		{
			return date1 >= date2 ? date1 : date2;
		}

		public static Date EarliestOf(Date date1, Date date2)
		{
			return date1 <= date2 ? date1 : date2;
		}

		public TimeSpan Subtract(Date subtrahend)
		{
			return date - subtrahend.BreachEncapsulationOfDateTime();
		}
	}
}
