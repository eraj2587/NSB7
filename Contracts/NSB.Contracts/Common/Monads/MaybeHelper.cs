using System.Collections.Generic;
using System.Linq;

namespace NSB.Contracts.Common.Monads
{
    public static class MaybeHelper
    {
        public static Maybe<T> AsOption<T>(this IEnumerable<T> enu)
        {
            return AsMaybeEx(enu, null);
        }

        public static Maybe<T> AsMaybeEx<T>(this IEnumerable<T> enu, string noneMessage)
        {
            if (!enu.Any())
                return Maybe<T>.None(noneMessage);
            else
                return Maybe<T>.Some(enu.FirstOrDefault());
        }
    }
}
