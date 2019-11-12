
namespace WUBS.Contracts.Common.Validation
{
    public interface IValidator
    {
        ValidationResult ValidationResult { get; }
    }

    public class Validator<T> : IValidator
    {
        private readonly T data;
        private readonly ValidationResult validationResult = new ValidationResult();

        public Validator(T data)
        {
            this.data = data;
        }

        public void AddError(int code, string description)
        {
            validationResult.Error(code, description);
        }

        public ValidationResult ValidationResult { get { return validationResult; } }
    }
}
