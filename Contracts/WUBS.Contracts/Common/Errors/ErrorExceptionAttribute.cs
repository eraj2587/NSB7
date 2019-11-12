using System;

namespace WUBS.Contracts.Common.Errors
{
    /// <summary>
    /// Decoration to describe the exception to use for a specific field or enumeration
    /// </summary>
    [AttributeUsage(AttributeTargets.Enum | AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public class ErrorExceptionAttribute : Attribute
    {
        /// <summary>
        /// The type of exception to create
        /// </summary>
        public Type ExceptionType { get; private set; }

        /// <summary>
        /// Construct an <see cref="ErrorExceptionAttribute"/> object.
        /// </summary>
        /// <param name="exceptionType">The type of exception to construct.</param>
        public ErrorExceptionAttribute(Type exceptionType)
        {
            ExceptionType = exceptionType;
        }
    }
}
