using WUBS.Cct.Treasury.Infrastructure.Exceptions;

namespace WUBS.Cct.Treasury.Infrastructure.Caches.Base
{
    public interface IValidatingCache<TValueType>
    {
        TValueType Validated(TValueType value);
    }

    public abstract class ValidatingCache<TValueType, TCacheType> : ItemTypeCache<TValueType, TCacheType>, IValidatingCache<TValueType>
            where TCacheType : ItemTypeCache<TValueType, TCacheType>, IValidatingCache<TValueType>, new()
    {
        public TValueType Validated(TValueType value)
        {
            if (CacheDictionary.ContainsValue(value))
                return value;
            throw new InvalidCacheItemException(string.Format(" cache {0}. Value {1} was not found in ", CacheName, value.ToString()));
        }
    }
}

