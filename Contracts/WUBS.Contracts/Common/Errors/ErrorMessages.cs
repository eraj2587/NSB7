using System;
using System.Globalization;
using System.Reflection;
using System.Resources;

namespace WUBS.Contracts.Common.Errors
{
    public static class ErrorMessages
    {
        public static CultureInfo GlobalCultureOverride { get; set; }

        /// <summary>
        /// Sets the <see cref="CultureInfo"/> to be used for resource management lookups for the given type.
        /// </summary>
        /// <param name="type">The type to associate the <c>culture</c> to.</param>
        /// <param name="culture">The <see cref="CultureInfo"/> to associate.</param>
        /// <returns>The previoud <see cref="CultureInfo"/> setting.</returns>
        public static CultureInfo SetErrorManagementCultureInfoOverride(this Type type, CultureInfo culture)
        {
            ResourceInfo info = ResourceManagerCache.ResourceInfoForType(type);
            CultureInfo oldValue = info.CultureOverride;
            info.CultureOverride = culture;
            return oldValue;
        }

        public static string FormatErrorString(this System.Enum enumeration, params object[] information)
        {
            return enumeration.FormatErrorString(null, information);
        }

        /// <summary>
        /// Retrieve error code errorFormat string for the enumeration code and perform a <see cref="System.String.Format(IFormatProvider, string, object[])"/> operation upon it
        /// using the currently selected <see cref="CultureInfo"/> object (if any).
        /// </summary>
        /// <param name="enumeration">The enumeration value to lookup in resources.</param>
        /// <param name="culture">A <see cref="CultureInfo"/> used to control the lookup and formating. (Overrides the setting specified with <see cref="SetErrorManagementCultureInfoOverride"/>
        /// and <see cref="ErrorMessages.GlobalCultureOverride"/></param>
        /// <param name="information">A variable number of arguments to insert into the format string.</param>
        /// <returns>The formatted error string.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "We only want to properly extend the more specific System.Enum.")]
        public static string FormatErrorString(this System.Enum enumeration, CultureInfo culture, params object[] information)
        {
            Type enumType = enumeration.GetType();
            ResourceInfo info = ResourceManagerCache.ResourceInfoForType(enumType);
            if (culture == null)
            {
                culture = info.CultureOverride ?? GlobalCultureOverride;
            }

            string formatName = enumeration.ToString();
            ResourceManager rm = info.ResourceManager;
            string errorFormat = rm.GetString(string.Concat(enumType.Name, ".", formatName), culture)
                ?? rm.GetString(formatName, culture);

            if (errorFormat == null)
            {
                throw new NotSupportedException(ErrorCode.MissingStringDefinition.FormatErrorString(enumType.Name, formatName));
            }

            // TODO: Add prefix information for string...
            string finalFormat = rm.GetString("_ErrorMessageFormat", culture) ?? "{2}({1}): {0}";

            return string.Format(CultureInfo.InvariantCulture, finalFormat,
                string.Format(culture, errorFormat, information),                   // {0} is the formatted error message
                ((IConvertible)enumeration).ToInt32(CultureInfo.CurrentCulture),    // {1} is the number assigned to the enumeration
                enumType.Namespace,                                                 // {2} is the namespace of the enumeration type
                enumType.Name,                                                      // {3} is the name of the enumeration type
                enumeration.ToString());                                            // {4} is the name of the enumeration field
        }

        /// <summary>
        /// Create an exception for an error code.
        /// </summary>
        /// <param name="enumeration">The enumeration field specifying the error to create.</param>
        /// <param name="information">Formatting information specific to the error string.</param>
        /// <returns></returns>
        public static Exception Exception(this System.Enum enumeration, params object[] information)    
        {
            Type enumerationType = enumeration.GetType();
            ConstructorInfo constructor;

            object[] attrs = enumerationType.GetField(enumeration.ToString()).GetCustomAttributes(typeof(ErrorExceptionAttribute), true);
            if (attrs == null || attrs.Length == 0)
            {
                constructor = ResourceManagerCache.ResourceInfoForType(enumerationType).DefaultExceptionConstructor;
            }
            else
            {
                ErrorExceptionAttribute attribute = (ErrorExceptionAttribute)(attrs[0]);
                constructor = attribute.ExceptionType.GetConstructor(new Type[] { typeof(string) });
                if (constructor == null)
                {
                    throw ErrorCode.ExceptionDoesNotContainProperConstructor_String.Exception(attribute.ExceptionType);
                }
            }
            return (Exception)constructor.Invoke(new object[] { enumeration.FormatErrorString(information) });
        }

    
    }
}
