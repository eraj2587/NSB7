using System;
using System.Data.SqlClient;
using WUBS.Cct.Treasury.Infrastructure.Monads;

namespace WUBS.Cct.Treasury.Infrastructure.Utilities
{
    public static class DbReadingUtility
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

        public static DateTime NullableDateTime(object obj)
        {
            if (obj is DBNull)
                return DateTime.MinValue;

            return Convert.ToDateTime(obj);
        }

        public static DateTime? NullableDateTime(object obj, DateTime? defaultValue)
        {
            if (obj is DBNull)
                return defaultValue;

            return Convert.ToDateTime(obj);
        }

        public static DateTime TimeZoneAdjustedNullableDateTime(object obj)
        {
            if (obj is DBNull)
                return DateTime.MinValue;

            return TimeZoneAdjustedDateTime(obj);
        }

        public static DateTime TimeZoneAdjustedDateTime(object obj)
        {
            DateTime dt = DateTime.SpecifyKind(Convert.ToDateTime(obj), DateTimeKind.Unspecified);

            return TimeZoneInfo.ConvertTime(dt, DbTimeZone, LocalTimeZone);
        }

        public static int? NullableInt(object obj, int? defaultValue)
        {
            if (obj is DBNull)
                return defaultValue;

            return Convert.ToInt32(obj);
        }

        public static int NullableInt(object obj)
        {
            if (obj is DBNull)
                return 0;

            return Convert.ToInt32(obj);
        }

        public static long NullableLong(object obj)
        {
            if (obj is DBNull)
                return 0;

            return Convert.ToInt64(obj);
        }

        public static Option<int> OptionInt(object obj)
        {
            if (obj is DBNull)
                return Option<int>.None;

            return Option<int>.Some(Convert.ToInt32(obj));

        }

        public static Option<object> OptionalColumn(SqlDataReader reader, string columnName)
        {
            try
            {
                return Option<object>.Some(reader[columnName]);
            }
            catch (IndexOutOfRangeException)
            {
                return Option<object>.None;
            }
        }


        public static T NullableObject<T>(object obj, Func<object, T> cast)
        {
            if (obj is DBNull)
                return default(T);

            return cast(obj);
        }

        public static bool NullableBoolean(object obj)
        {
            if (obj is DBNull)
                return false;

            return Convert.ToBoolean(obj);
        }

        public static decimal NullableDecimal(object obj)
        {
            if (obj is DBNull)
                return decimal.Zero;

            return Convert.ToDecimal(obj);
        }

        public static decimal? NullableDecimal(object obj, decimal? defaultValue)
        {
            if (obj is DBNull)
                return defaultValue;

            return Convert.ToDecimal(obj);
        }

        public static string NullableString(object obj)
        {
            if (obj is DBNull)
                return string.Empty;

            return Convert.ToString(obj);
        }

        public static string CanBeNullString(object obj)
        {
            if (obj is DBNull || obj == null)
                return null;

            return Convert.ToString(obj).Trim();
        }
    }
}
