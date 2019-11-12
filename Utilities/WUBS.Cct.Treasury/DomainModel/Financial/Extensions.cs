using System;
using System.Collections.Generic;
using System.Linq;

namespace WUBS.Cct.Treasury.DomainModel.Financial
{
    public static class Extensions
    {
        public static Money Sum(this IEnumerable<Money> source)
        {
            return source.Aggregate((x, y) => x + y);
        }

        public static Money Sum<T>(this IEnumerable<T> source, Func<T, Money> selector)
        {
            return source.Select(selector).Aggregate((x, y) => x + y);
        }
    }
}
