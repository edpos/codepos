using System;
using System.Collections.Generic;
using System.Configuration;
using System.Runtime.Caching;

namespace iTanec.eCom.Services.CacheManagement
{
    public enum CachePriority
    {
        Default,
        NotRemovable
    }

    /// <summary>
    /// Cache Manager is base class that implements how cahching is handled.
    /// </summary>
    /// <history>
    ///  Author				:	Saravanan R
    ///  Creation Date		:	18/1/2014
    ///  Last revised		:
    ///  Revision history	:
    /// </history>
    public class ProductCacheManager
    {
        // Gets a reference to the default MemoryCache instance.
        private static readonly ObjectCache cache = MemoryCache.Default;

        private static CacheItemPolicy policy = null;

        //  private CacheEntryRemovedCallback callback = null;
        private static double ExpirationTime = Convert.ToDouble(ConfigurationManager.AppSettings["CacheExpiration"]);

        //private static double ExpirationTime = 12.00;

        // File based Cache dependency
        /// <summary>
        /// Add to my cache with file path as input param for File based CacheDependency
        /// </summary>
        /// <history>
        ///  Author				:	Saravanan R
        ///  Creation Date		:	21/1/2014
        ///  Last revised		:
        ///  Revision history	:
        /// </history>
        public static void AddToMyCache(String CacheKeyName, Object CacheItem, CachePriority MyCacheItemPriority, List<String> FilePath)
        {
            policy = new CacheItemPolicy();
            policy.Priority = (MyCacheItemPriority == CachePriority.Default) ?
                    CacheItemPriority.Default : CacheItemPriority.NotRemovable;
            policy.AbsoluteExpiration = DateTimeOffset.Now.AddHours(ExpirationTime);
            // policy.RemovedCallback = callback;
            policy.ChangeMonitors.Add(new HostFileChangeMonitor(FilePath));
            // Add inside cache
            cache.Set(CacheKeyName, CacheItem, policy);
        }

        /// <summary>
        /// Add to my cache with file path as input param
        /// </summary>
        /// <history>
        ///  Author				:	Saravanan R
        ///  Creation Date		:	21/1/2014
        ///  Last revised		:
        ///  Revision history	:
        /// </history>
        public static void AddToMyCache(String CacheKeyName, Object CacheItem, CachePriority MyCacheItemPriority, string regionName = null)
        {
            policy = new CacheItemPolicy();
            policy.Priority = (MyCacheItemPriority == CachePriority.Default) ?
                    CacheItemPriority.Default : CacheItemPriority.NotRemovable;
            policy.AbsoluteExpiration = DateTimeOffset.Now.AddHours(ExpirationTime);
            //policy.RemovedCallback = CachedItemRemovedCallback;
            // Add inside cache
            cache.Set(CacheKeyName, CacheItem, policy, regionName);
        }

        /// <summary>
        /// Get Cache Data
        /// </summary>
        /// <returns>
        /// generic type of cached object
        /// </returns>
        /// <history>
        ///  Author				:	Saravanan R
        ///  Creation Date		:	21/1/2014
        ///  Last revised		:
        ///  Revision history	:
        /// </history>
        public static T GetCachedItem<T>(String CacheKeyName) where T : class
        {
            try
            {
                // retrieve and return
                return cache[CacheKeyName] as T;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Remove cached item based on the key
        /// </summary>
        /// <history>
        ///  Author				:	Saravanan R
        ///  Creation Date		:	21/1/2014
        ///  Last revised		:
        ///  Revision history	:
        /// </history>
        public static void RemoveCachedItem(String CacheKeyName)
        {
            // remove it from the case
            if (cache.Contains(CacheKeyName))
            {
                cache.Remove(CacheKeyName);
            }
        }

        /// <summary>
        ///Cached Remove item for logging purpose
        /// </summary>
        /// <history>
        ///  Author				:	Saravanan R
        ///  Creation Date		:	21/1/2014
        ///  Last revised		:
        ///  Revision history	:
        /// </history>
        private void CachedItemRemovedCallback(CacheEntryRemovedArguments arguments)
        {
            // Log these values from arguments list
            String strLog = String.Concat("Reason: ", arguments.RemovedReason.ToString(), " | Key-Name: ", arguments.CacheItem.Key, " | Value-Object: ", arguments.CacheItem.Value.ToString());
            // To be implemented at system level log
        }
    }
}