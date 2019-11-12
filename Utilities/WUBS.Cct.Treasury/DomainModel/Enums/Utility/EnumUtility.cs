using System;
using System.ComponentModel;
using System.Reflection;
using WUBS.Cct.Treasury.DomainModel.Enums.Utility.Exceptions;

namespace WUBS.Cct.Treasury.DomainModel.Enums.Utility
{
    public static class EnumUtility
    {
        public static string StringValueOf(System.Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (attributes.Length > 0)
                return attributes[0].Description;

            return value.ToString();
        }

        public static string CctCodeValueOf(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            var cctCodeAttributes = (CctCodeAttribute[]) fi.GetCustomAttributes(typeof(CctCodeAttribute), false);
            if (cctCodeAttributes.Length > 0)
            {
                return cctCodeAttributes[0].Value;
            }

            return null;
            //throw new ArgumentException(string.Format("Enum {0} does not have CCT Code attribute.", value.GetType().Name));
        }

        public static object EnumValueOfCttCode(string cctCode, Type enumType)
        {
            string[] names = Enum.GetNames(enumType);
            foreach (string name in names)
            {
                if (cctCode.Equals(CctCodeValueOf((Enum)Enum.Parse(enumType, name))))
                    return Enum.Parse(enumType, name);
            }

            throw new UnexpectedCctCodeException(cctCode, enumType);
        }

        public static TType ConvertTo<TType>(this Enum enumeration)
        {
            return (TType)Enum.Parse(typeof(TType), enumeration.ToString());
        }
    }
}
