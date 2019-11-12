using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace WUBS.Utilities.Common
{
    public static class Helper
	{
		public static string MaskAccountNumber(string accountNumber)
		{
			int unmaskedLength = 4;

			if (!string.IsNullOrEmpty(accountNumber))
			{
				if (accountNumber.Length <= unmaskedLength)
				{
					return accountNumber;
				}
				else
				{
					string unmaskedNumber = accountNumber.Substring(accountNumber.Length - unmaskedLength);
					return unmaskedNumber.PadLeft(accountNumber.Length, '*');
				}
			}

			return string.Empty;
		}

		public static string Serialize<T>(T @object, bool omitXmlDeclaration)
		{
			XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
			xmlWriterSettings.OmitXmlDeclaration = omitXmlDeclaration;
			xmlWriterSettings.Encoding = Encoding.UTF8;

			StringBuilder stringBuilder = new StringBuilder();

			using (XmlWriter streamWriter = XmlTextWriter.Create(stringBuilder, xmlWriterSettings))
			{
				XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));

				XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
				namespaces.Add(string.Empty, string.Empty);

				xmlSerializer.Serialize(streamWriter, @object, namespaces);
			}

			return stringBuilder.ToString().Trim();
		}

		public static string ReadContents(string fileName)
        {
            if (!File.Exists(fileName)) return string.Empty;
            return File.ReadAllText(fileName);
		}

        public static List<string> ExtractString(string value, char delimeter)
        {
            var list = new List<string>();

            if (!string.IsNullOrEmpty(value))
                list = value.Split(delimeter).ToList<string>();

            return list;
        }

        public static string GetExceptionDetailsByException(Exception ex)
        {
            var errorCode = "";

            if (ex is DivideByZeroException)
                errorCode = "System error : ";
            else if (ex is NotFiniteNumberException)
                errorCode = "System error : ";
            else if (ex is SqlException)
                errorCode = "Database error : ";
            else if (ex is IOException)
                errorCode = "File read error : ";
            else if (ex is WebException)
                errorCode = "Network failure : ";
            else if (ex is ApplicationException)
                errorCode = "Application error : ";
            else
                errorCode = "Application error : ";

            errorCode = errorCode + ex.Message;
            return errorCode;
        }

        public static void SendSQLIntegratedMessage(string message, string endPointTable, string connectionString)
        {
            var insertSql = "insert into " + endPointTable + "(Id, Recoverable, Headers, Body)" +
                            "values (@Id, @Recoverable, @Headers, @Body)";
            var connection = new SqlConnection(connectionString);
            connection.Open();
            using (var command = new SqlCommand(insertSql, connection))
            {
                var parameters = command.Parameters;
                parameters.Add("Id", SqlDbType.UniqueIdentifier).Value = Guid.NewGuid();
                parameters.Add("Headers", SqlDbType.NVarChar).Value = "";
                parameters.Add("Body", SqlDbType.VarBinary).Value = Encoding.UTF8.GetBytes(message);
                parameters.Add("Recoverable", SqlDbType.Bit).Value = true;
                command.ExecuteNonQuery();
            }
        }
    }
    //public static class EnumsHelperExtension
    //{
    //    public static string ToDescription(this Enum value)
    //    {
    //        DescriptionAttribute[] descriptionAttributes = (DescriptionAttribute[])(value.GetType().GetField(value.ToString())).GetCustomAttributes(typeof(DescriptionAttribute), false);
    //        return descriptionAttributes.Length > 0 ? descriptionAttributes[0].Description : value.ToString();
    //    }
    //}
    public static class StringHelper
    {
        public static string JoinElements<T>(this T[] array,char sperator)
        {
            if (typeof (T) == typeof (short) || typeof (T) == typeof (int) || typeof (T) == typeof (long) ||
                typeof (T) == typeof (string))
            {
                if (array.Length > 0)
                {
                    StringBuilder strBuilder = new StringBuilder();
                    int i = 0;
                    for (i = 0; i < array.Length - 1; i++)
                    {
                        strBuilder.Append(array[i]).Append(sperator);
                    }
                    if (i == array.Length - 1)
                    {
                        strBuilder.Append(array[i]);
                    }
                    return strBuilder.ToString();
                }
                return string.Empty;
            }
            return null;
        }

        public static string DecodeFromBase64(this string value)
        {
           return Encoding.UTF8.GetString(Convert.FromBase64String(value));
        }
      
    }
}
