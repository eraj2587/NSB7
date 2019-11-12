using System;
using System.Collections.Generic;
using System.Linq;
using WUBS.Cct.Treasury.DomainModel.Enums.Utility;
using WUBS.Cct.Treasury.DomainModel.Enums.Utility.Exceptions;
using WUBS.Cct.Treasury.Infrastructure.Exceptions;

namespace WUBS.Cct.Treasury.Infrastructure.Caches
{
    public abstract class Cache<TValueType, TCacheType> : ICacheDependencies where TCacheType : Cache<TValueType, TCacheType>, new()
    {
        private static Dictionary<int, TValueType> cacheDictionary;
        private static TCacheType instance;

        protected abstract string CacheName { get; }
        protected abstract Dictionary<int, string> GetCodeMapping();

        public virtual int InitializationOrder { get { return (GetCacheDependencies().Count == 0 ? 0 : GetCacheDependencies().Max(cd => cd.InitializationOrder)) + 1; } }

        protected Cache() { }

        public static TCacheType Instance
        {
            get
            {
                if (instance != null)
                    return instance;

                instance = new TCacheType();
                instance.Created();
                return instance;
            }
            set { instance = value; }
        }

        protected virtual void Created() { }

        public List<TValueType> AllValues
        {
            get { return CacheDictionary.Values.ToList(); }
        }

        public void Initialize()
        {
            if (cacheDictionary == null)
                cacheDictionary = LoadCacheDictionary();
        }

        public void Reinitialize()
        {
            cacheDictionary = LoadCacheDictionary();
        }

        public bool IsInitialized
        {
            get { return cacheDictionary != null; }
        }

        protected virtual Dictionary<int, TValueType> LoadCacheDictionary()
        {
            Dictionary<int, string> mappings = GetCodeMapping();

            var items = new Dictionary<int, TValueType>();
            var notFoundCctCodes = "";
            foreach (var mapping in mappings)
            {
                try
                {
                    items.Add(mapping.Key, (TValueType)EnumUtility.EnumValueOfCttCode(mapping.Value, typeof(TValueType)));
                }
                catch (UnexpectedCctCodeException ex)
                {
                    // We have encountered an item whose CCT Code we do not yet have in our enumeration.
                    notFoundCctCodes += ex.CctCode + ";";
                }
            }

            //if (notFoundCctCodes.Length > 0)
            //{
            //    var logger = LogManager.GetLogger<TCacheType>();
            //    logger.WarnFormat("The following cctCode values do not exist for specified enum {0}: {1}",
            //        typeof(TValueType).Name, notFoundCctCodes);
            //}

            return items;
        }

        protected Dictionary<int, TValueType> CacheDictionary
        {
            get
            {
                //Initialize();
                if (cacheDictionary == null)
                    throw new Exception(string.Format("Cache {0} was not initialized yet.", CacheName));
                return cacheDictionary;
            }
        }

        public virtual TValueType GetById(int id)
        {
            TValueType returnValue;
            if (!CacheDictionary.TryGetValue(id, out returnValue))
                throw new InvalidCacheItemException(CacheName + " : " + id);
            return returnValue;
        }

        public virtual int GetId(TValueType value)
        {
            foreach (var pair in CacheDictionary.Where(pair => pair.Value.Equals(value)))
                return pair.Key;

            throw new InvalidCacheItemException(CacheName + " : " + value);
        }

        public void InitializeCacheDictionaryForTesting(Dictionary<int, TValueType> testCacheDictionary)
        {
            cacheDictionary = testCacheDictionary;
        }

        public virtual List<ICacheDependencies> GetCacheDependencies()
        {
            return new List<ICacheDependencies>();
        }
    }
}
