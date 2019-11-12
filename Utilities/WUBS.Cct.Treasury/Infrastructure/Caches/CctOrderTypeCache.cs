using System.Collections.Generic;
using WUBS.Cct.Treasury.DomainModel.Entities;
using WUBS.Cct.Treasury.Infrastructure.Caches.Mappers;

namespace WUBS.Cct.Treasury.Infrastructure.Caches
{
    public class CctOrderTypeCache : Cache<CctOrderType, CctOrderTypeCache>
    {
        protected override Dictionary<int, CctOrderType> LoadCacheDictionary()
        {
            return CctOrderTypeCacheMapper.Instance.GetAllCctOrderTypesDictionary();
        }

        protected override string CacheName
        {
            get { return "Cct Order Type"; }
        }

        protected override Dictionary<int, string> GetCodeMapping()
        {
            return null;
        }

        public override CctOrderType GetById(int id)
        {
            CctOrderType returnValue;
            return !CacheDictionary.TryGetValue(id, out returnValue) ? null : returnValue;
        }
    }
}
