using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
namespace NSB.Contracts.Common.Validation
{
    [DataContract]
    public class ValidationResult
    {
        [DataMember] 
        private readonly List<ValidationError> errors = new List<ValidationError>();

        public void Error(int code, string description)
        {
            errors.Add(new ValidationError(code, description));
        }

        public bool IsValid { get { return errors.Count == 0; } }
        public IEnumerable<ValidationError> Errors { get { return errors; } }

        public string ToErrorMessage()
        {
            return string.Join("\n", errors.Select(error => error.ToString()));
        }
    }
}
