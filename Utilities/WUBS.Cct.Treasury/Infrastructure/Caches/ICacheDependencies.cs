using System.Collections.Generic;

namespace WUBS.Cct.Treasury.Infrastructure.Caches
{
    public interface ICacheDependencies
    {
        List<ICacheDependencies> GetCacheDependencies();
        int InitializationOrder { get; }
    }
}
