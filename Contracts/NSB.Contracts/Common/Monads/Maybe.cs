using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace NSB.Contracts.Common.Monads
{
    [DataContract]
    [JsonObject]
    public struct Maybe<T> : IEnumerable<T>
    {
        [DataMember]
        [JsonProperty]
        private readonly T value;
        public T Value { get { return value; } }

        [DataMember]
        [JsonProperty]
        private readonly bool isSome;
        public bool IsSome { get { return isSome; } }
        public bool IsEmpty { get { return !isSome; } }

        [DataMember]
        [JsonProperty]
        private readonly string noneMessage;

        private Maybe(T value, bool isSome, string noneMessage)
        {
            this.value = value;
            this.isSome = isSome && (value != null);
            this.noneMessage = this.isSome ? null : (noneMessage ?? string.Format("Option<{0}> does not contain value", typeof(T).Name));
        }

        public static Maybe<T> None(string noneMessage = null)
        {
            return new Maybe<T>(default(T), false, noneMessage);
        }

        public static Maybe<T> Some(T value)
        {
            return new Maybe<T>(value, true, null);
        }

        public static implicit operator Maybe<T>(T value)
        {
            return Some(value);
        }

        public TRes Match<TRes>(Func<T, TRes> some, Func<TRes> none)
        {
            return IsSome ? some.Invoke(Value) : none.Invoke();
        }

        public void Match(Action<T> some, Action none)
        {
            if (IsSome)
                some.Invoke(Value);
            else
                none.Invoke();
        }

        public void ForEach(Action<T> action)
        {
            if (IsSome)
                action(Value);
        }

        public Maybe<TRes> Map<TRes>(Func<T, TRes> func)
        {
            return IsSome ? Maybe<TRes>.Some(func(Value)) : Maybe<TRes>.None(noneMessage);
        }

        public Maybe<TRes> FlatMap<TRes>(Func<T, Maybe<TRes>> func)
        {
            return IsSome ? func(Value) : Maybe<TRes>.None(noneMessage);
        }

        public T GetOrElse(T other)
        {
            return IsSome ? Value : other;
        }

        public T GetOrThrow(Func<string, Exception> onNone)
        {
            if (!IsSome)
                throw onNone(noneMessage);
            return Value;
        }

        public T Get()
        {
            return GetOrThrow(message => new ApplicationException(message));
        }

        public IEnumerator<T> GetEnumerator()
        {
            if (IsSome)
                yield return Value;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
