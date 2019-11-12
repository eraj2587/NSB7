using System;
using System.Collections;
using System.Collections.Generic;

namespace WUBS.Cct.Treasury.Infrastructure.Monads
{
    public class Result<T, E> : IEnumerable<T> where E : Exception
    {
        private readonly T value;
        private readonly E e;

        public static Result<T, E> New(Func<T> vFunc)
        {
            try
            {
                var value = vFunc();
                return new Result<T, E>(value);
            }
            catch (E ex)
            {
                return new Result<T, E>(ex);
            }
        }

        public Result(T value)
        {
            this.value = value;
            this.e = null;
        }

        public Result(E e)
        {
            if (e == null)
                throw new ArgumentException("Result's exception is not nullable");
            this.e = e;
            this.value = default(T);
        }

        public bool IsOk { get { return this.e == null; } }

        public T GetOrThrow()
        { 
            if (!IsOk) throw e;
            return value;
        }

        public TRes Match<TRes>(Func<T, TRes> value, Func<Exception, TRes> error)
        {
            if (IsOk)
                return value.Invoke(this.value);
            else
                return error.Invoke(e);
        }

        //public void Match(Action<T> value, Action<Exception> error)
        //{
        //    if (IsOk)
        //        value.Invoke(this.value);
        //    else
        //        error.Invoke(e);
        //}

        public Result<TRes, E> Map<TRes>(Func<T, TRes> func)
        {
            if (!IsOk)
                return new Result<TRes, E>(e);

            try
            {
                return new Result<TRes, E>(func(value));
            }
            catch (E ex)
            {
                return new Result<TRes, E>(ex);
            }
        }

        public Result<T, E> ForEach(Action<T> action)
        {
            if (!IsOk)
                return this;

            try
            {
                action(value);
                return new Result<T, E>(value);
            }
            catch (E ex)
            {
                return new Result<T, E>(ex);
            }
        }

        public Result<TRes, E> FlatMap<TRes>(Func<T, Result<TRes, E>> func)
        {
            if (IsOk)
                return func(value);
            else
                return new Result<TRes, E>(e);
        }

        public IEnumerator<T> GetEnumerator()
        {
            if (IsOk)
                yield return value;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

    }
}
