using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MY7W.Tools.Cache
{
    public class CacheFactory
    {
        //private ICacheInstance iCacheInstance;

        public CacheFactory()
        {
        }

        public static ICacheInstance GetInstance()
        {
            return new CacheInstanceAspNet();
        }

        //public static ICacheInstance GetInstance(bool isMemcach)
        //{
        //    return new CacheInstanceMemcached();
        //}
    }
}
