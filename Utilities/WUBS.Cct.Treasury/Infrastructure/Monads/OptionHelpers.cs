using System.Collections.Generic;
using System.Linq;

namespace WUBS.Cct.Treasury.Infrastructure.Monads
{
    public static class OptionHelpers
    {
        public static Option<T> AsOption<T>(this IEnumerable<T> enu)
        {
            if (!enu.Any())
                return Option<T>.None;
            else
                return Option<T>.Some(enu.FirstOrDefault());
        }
    }
}
