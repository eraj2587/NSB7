using System;

namespace WUBS.Cct.Treasury.Infrastructure.Utilities
{
    public static class DbWritingUtility
    {
        private static TimeZoneInfo dbTimeZone;
        internal static TimeZoneInfo DbTimeZone
        {
            get { return dbTimeZone ?? (dbTimeZone = TimeZoneInfo.FindSystemTimeZoneById(AppSettingsReadingUtility.GetValue("DbSettings.TimeZone", TimeZoneInfo.Local.Id))); }
            set { dbTimeZone = value; }
        }

        private static TimeZoneInfo localTimeZone;
        internal static TimeZoneInfo LocalTimeZone
        {
            get { return localTimeZone ?? (localTimeZone = TimeZoneInfo.Local); }
            set { localTimeZone = value; }
        }

        public static DateTime DbTimeZoneAdjustedDateTime(DateTime localDateTime)
        {
            if (localDateTime == DateTime.MinValue)
                return localDateTime;

            DateTime dt = DateTime.SpecifyKind(localDateTime, DateTimeKind.Unspecified);

            return TimeZoneInfo.ConvertTime(dt, LocalTimeZone, DbTimeZone);
        }

        public static object ToDbNullWhenNull(Object obj)
        {
            if (obj == null)
                return DBNull.Value;

            return obj;
        }

        public static object ToDbNullWhenDateTimeMinValue(DateTime dateTime)
        {
            if (dateTime == DateTime.MinValue)
                return DBNull.Value;

            return dateTime;
        }

        public static object ToDbNullWhenStringIsEmpty(string stringValue)
        {
            if (String.IsNullOrEmpty(stringValue))
                return DBNull.Value;

            return stringValue;
        }
        
        public static object ToDbNullWhenIntegerIsZero(int intValue)
        {
            if (intValue == 0)
                return DBNull.Value;

            return intValue;
        }
    }
}
