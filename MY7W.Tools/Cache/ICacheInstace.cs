using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MY7W.Tools.Cache
{
    public interface ICacheInstance
    {
        /// <summary>
        /// 获取缓存对象
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        object GetObject(string key);

        /// <summary>
        /// 把对象加入换成
        /// </summary>
        /// <param name="key"></param>
        /// <param name="obj"></param>
        void AddObject(string key, object obj);

        /// <summary>
        /// 把对象加入缓存，并设置过期时间
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="obj">对象</param>
        /// <param name="timeoutSec">分钟为单位</param>
        void AddObjectWithTimeout(string key, object obj, int timeoutMinute);

        /// <summary>
        /// 删除缓存
        /// </summary>
        /// <param name="key"></param>
        void RemoveObject(string key);

        /// <summary>
        /// 删除所有缓存
        /// </summary>
        void RemoveAll();

        /// <summary>
        /// 删除相同前缀键的缓存
        /// </summary>
        /// <param name="extKey">AC、LINK、CATEGORY、IMG</param>
        //void RemoveAll(string extKey);

        //string GetCacheName();
    }
}
