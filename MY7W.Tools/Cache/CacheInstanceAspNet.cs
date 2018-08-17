using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MY7W.Tools.Cache
{
    public class CacheInstanceAspNet : ICacheInstance
    {

        /// <summary>
        /// 获取缓存对象
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public object GetObject(string key)
        {
            if (string.IsNullOrEmpty(key))
                return null;

            return HttpRuntime.Cache.Get(key);
        }


        /// <summary>
        /// 把对象加入换成
        /// </summary>
        /// <param name="key"></param>
        /// <param name="obj"></param>
        public void AddObject(string key, object obj)
        {
            if (!string.IsNullOrEmpty(key) && obj != null)
            {
                HttpRuntime.Cache.Insert(key, obj);
            }
        }


        /// <summary>
        /// 把对象加入缓存，并设置过期时间
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="obj">对象</param>
        /// <param name="timeoutSec">分钟为单位</param>
        public void AddObjectWithTimeout(string key, object obj, int timeoutMinute)
        {
            if (key == null || key.Length == 0 || obj == null || timeoutMinute <= 0)
            {
                return;
            }

            HttpRuntime.Cache.Insert(key, obj, null, System.DateTime.Now.AddMinutes(timeoutMinute), System.Web.Caching.Cache.NoSlidingExpiration);
        }


        /// <summary>
        /// 删除缓存
        /// </summary>
        /// <param name="key"></param>
        public void RemoveObject(string key)
        {
            if (key == null || key.Length == 0)
                return;

            HttpRuntime.Cache.Remove(key);
        }

        /// <summary>
        /// 删除所有缓存
        /// </summary>
        public void RemoveAll()
        {
            IDictionaryEnumerator CacheEnum = HttpRuntime.Cache.GetEnumerator();

            while (CacheEnum.MoveNext())
            {
                HttpRuntime.Cache.Remove(CacheEnum.Key.ToString());
            }
        }

        /// <summary>
        /// 删除相同前缀键的缓存
        /// </summary>
        /// <param name="extKey">AC、LINK、CATEGORY、IMG</param>
        public void RemoveAll(string extKey)
        {
            if (!string.IsNullOrEmpty(extKey) && extKey.Length > 0)
            {
                IDictionaryEnumerator CacheEnum = HttpRuntime.Cache.GetEnumerator();

                while (CacheEnum.MoveNext())
                {
                    if (CacheEnum.Key.ToString().IndexOf('_') == -1)
                        continue;

                    string key = CacheEnum.Key.ToString().Substring(0, CacheEnum.Key.ToString().LastIndexOf('_'));
                    if (key != "" && key == extKey)
                    {
                        HttpRuntime.Cache.Remove(CacheEnum.Key.ToString());
                    }
                }
            }
        }

        public string GetCacheName()
        {
            string str = "";
            IDictionaryEnumerator CacheEnum = HttpRuntime.Cache.GetEnumerator();

            while (CacheEnum.MoveNext())
            {
                str += "缓存名<b>[" + CacheEnum.Key + "]</b><br />";
            }
            str = "当前网站总缓存数:" + HttpRuntime.Cache.Count + "<br />" + str;

            return str;
        }
    }
}
