using System;
using System.Collections;
using System.Collections.Generic;

namespace WUBS.Cct.Treasury.Infrastructure.Monads
{
    public struct Option<T> : IEnumerable<T>
    {
        private readonly T value;
        public T Value { get { return value; } }

        private readonly bool isSome;
        public bool IsSome { get { return isSome; } }

        private Option(T value, bool isSome)
        {
            this.value = value;
            this.isSome = isSome && (value != null);
        }

        public static readonly Option<T> None = new Option<T>(default(T), false);

        public static Option<T> Some(T value)
        {
            return new Option<T>(value, true);
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

        public Option<TRes> Map<TRes>(Func<T, TRes> func)
        {
            return IsSome ? Option<TRes>.Some(func(Value)) : Option<TRes>.None;
        }

        public Option<TRes> FlatMap<TRes>(Func<T, Option<TRes>> func)
        {
            return IsSome ? func(Value) : Option<TRes>.None;
        }

        public T GetOrElse(T other)
        {
            return IsSome ? Value : other;
        }

        public T Get()
        {
            if (!IsSome)
                throw new Exception("Option does not contain value");
            return Value;
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
