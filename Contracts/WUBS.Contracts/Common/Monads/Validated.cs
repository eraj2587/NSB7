using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using WUBS.Contracts.Common.Validation;

namespace WUBS.Contracts.Common.Monads
{
    [DataContract]
    [JsonObject]
    public class Validated<T> : IEnumerable<T>
    {
        [DataMember]
        [JsonProperty]
        private readonly T value;
        [DataMember]
        [JsonProperty]
        private readonly ValidationResult validationResult;

        private Validated(T value, ValidationResult validationResult)
        {
            this.value = value;
            this.validationResult = validationResult;
        }

        public static Validated<T> CreateValid(T value)
        {
            return new Validated<T>(value, new ValidationResult());
        }

        public static Validated<T> CreateInvalid(ValidationResult errors)
        {
            if (errors.IsValid)
                throw new ApplicationException("Constructing Invalid instance without actual errors");

            return new Validated<T>(default(T), errors);
        }

        public static Validated<T> CreateInvalid(ValidationResult errors, T value)
        {
            if (errors.IsValid)
                throw new ApplicationException("Constructing Invalid instance without actual errors");

            return new Validated<T>(value, errors);
        }


        public bool IsValid { get { return validationResult.IsValid; } }
        public IEnumerable<ValidationError> Errors { get { return validationResult.Errors; } }
        public ValidationResult ValidationResult { get { return validationResult; } }

        public Validated<TRes> Map<TRes>(Func<T, TRes> func)
        {
            return IsValid ? Validated<TRes>.CreateValid(func(value)) : Validated<TRes>.CreateInvalid(validationResult);
        }

        public Validated<TRes> FlatMap<TRes>(Func<T, Validated<TRes>> func)
        {
            return IsValid ? func(value) : Validated<TRes>.CreateInvalid(validationResult);
        }

        public T GetOrElse(T other)
        {
            return IsValid ? value : other;
        }

        public T GetOrThrow(Func<ValidationResult, Exception> onInvalid)
        {
            if (!IsValid)
                throw onInvalid(validationResult);
            return value;
        }

        public T GetOrThrowInvalid(Func<ValidationResult, Exception> onInvalid)
        {
            return value;
        }

        public T GetInvalid()
        {
            return GetOrThrowInvalid(result => MakeException("Validation failed"));
        }

        public T Get()
        {
            return GetOrThrow(result => MakeException("Validation failed"));
        }

        public Exception MakeException(string messageHeader)
        {
            return new ValidationException(messageHeader, validationResult);
        }

        public T GetOrFault()
        {
            return GetOrThrow(result =>
                new FaultException<ValidationFault>(new ValidationFault(), new FaultReason(result.ToErrorMessage())));
        }

        public IEnumerator<T> GetEnumerator()
        {
            if (IsValid)
                yield return value;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
