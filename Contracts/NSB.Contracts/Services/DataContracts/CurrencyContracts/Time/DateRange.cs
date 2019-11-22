using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace NSB.Contracts.Services.DataContracts.CurrencyContracts.Time
{
    public class DateRangeConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
        
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jObject = JObject.Load(reader);
            return new DateRange(Convert.ToDateTime(jObject.Property("Start").Value), Convert.ToDateTime(jObject.Property("End").Value));
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof(DateRange).IsAssignableFrom(objectType);
        }
    }

    [Serializable]
    public class DateRange
    {
        public readonly Date Start;
        public readonly Date End;

        [JsonConstructor]
        public DateRange(Date start, Date end)
        {
            Start = start;
            End = end;
        }

        public DateRange(DateTime start, DateTime end)
        {
            Start = new Date(start);
            End = new Date(end);
        }

        public bool Contains(Date date)
        {
            return Start <= date && date <= End;
        }

        public override string ToString()
        {
            return string.Format("{0} to {1}", Start, End);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;

            if (ReferenceEquals(this, obj))
                return true;

            if (obj.GetType() != typeof (DateRange))
                return false;

            return Equals((DateRange) obj);
        }

        public bool Equals(DateRange other)
        {
            if (ReferenceEquals(null, other))
                return false;

            if (ReferenceEquals(this, other))
                return true;

            return other.Start.Equals(Start) && other.End.Equals(End);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Start.GetHashCode()*397) ^ End.GetHashCode();
            }
        }
    }
}
