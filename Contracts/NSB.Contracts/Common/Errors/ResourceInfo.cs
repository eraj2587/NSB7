using System;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;

namespace NSB.Contracts.Common.Errors
{
    /// <summary>
    /// All resource management information for a specific type
    /// </summary>
    internal class ResourceInfo
    {
        private Type m_ResourceType;

        /// <summary>
        /// Construct a <see cref="ResourceInfo"/> object.
        /// </summary>
        /// <param name="type"></param>
        internal ResourceInfo(Type type)
        {
            m_ResourceType = type;

            // Determine Resource Manager to use
            ErrorStringResourceAttribute attr = (ErrorStringResourceAttribute)(type.GetCustomAttributes(typeof(ErrorStringResourceAttribute), true).FirstOrDefault())
                ?? (ErrorStringResourceAttribute)(m_ResourceType.Assembly.GetCustomAttributes(typeof(ErrorStringResourceAttribute), true).FirstOrDefault())
                ?? new ErrorStringResourceAttribute("ErrorStrings", type);

            if (attr.IsRedirect)
            {
                ResourceManager = ResourceManagerCache.ResourceInfoForType(attr.Redirect).ResourceManager;
            }
            else
            {
                ResourceManager = new ResourceManager(attr.Path, type.Assembly);
            }

            ErrorExceptionAttribute exceptionAttr = (ErrorExceptionAttribute)(type.GetCustomAttributes(typeof(ErrorExceptionAttribute), true).FirstOrDefault());
            DefaultExceptionConstructor =
                (exceptionAttr == null ? typeof(ApplicationException) : exceptionAttr.ExceptionType)
                .GetConstructor(new Type[] { typeof(string) });
            if (DefaultExceptionConstructor == null)
            {
                throw ErrorCode.ExceptionDoesNotContainProperConstructor_String.Exception(exceptionAttr.ExceptionType);
            }
        }

        /// <summary>
        /// The Resource Manager used to obtain strings for the associated type
        /// </summary>
        internal ResourceManager ResourceManager { get; private set; }

        /// <summary>
        /// A <see cref="CultureInfo"/> object to be used for resource lookups and formatting.
        /// </summary>
        internal CultureInfo CultureOverride;

        /// <summary>
        /// Default constructor to use for exception handling.
        /// </summary>
        internal ConstructorInfo DefaultExceptionConstructor { get; private set; }

    }
}
