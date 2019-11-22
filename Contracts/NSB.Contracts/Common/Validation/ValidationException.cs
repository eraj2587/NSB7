using System;

namespace NSB.Contracts.Common.Validation
{
    public class ValidationException : ApplicationException
    {
        public ValidationResult Result { get; set; }

        private static string ExceptionMessage(string messageHeader, ValidationResult validationResult)
        {
            return string.Join(":\n", messageHeader, validationResult.ToErrorMessage());
        }

        public ValidationException(string messageHeader, ValidationResult result) : 
            base(ExceptionMessage(messageHeader, result))
        {
            Result = result;
        }
    }
}
