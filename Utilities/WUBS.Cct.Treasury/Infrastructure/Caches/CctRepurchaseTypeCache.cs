using System.Collections.Generic;
using WUBS.Cct.Treasury.DomainModel.Entities;
using WUBS.Cct.Treasury.Infrastructure.Caches.Mappers;

namespace WUBS.Cct.Treasury.Infrastructure.Caches
{
    public class CctRepurchaseTypeCache : Cache<CctRepurchaseType, CctRepurchaseTypeCache>
    {
        protected override Dictionary<int, CctRepurchaseType> LoadCacheDictionary()
        {
            return CctOrderTypeCacheMapper.Instance.GetAllCctRepurchaseTypesDictionary();
        }

        protected override string CacheName
        {
            get { return "Cct Repurchase Type"; }
        }

        protected override Dictionary<int, string> GetCodeMapping()
        {
            return null;
        }

        public override CctRepurchaseType GetById(int id)
        {
            CctRepurchaseType returnValue;
            return !CacheDictionary.TryGetValue(id, out returnValue) ? null : returnValue;
        }
    }
}
