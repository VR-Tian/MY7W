using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MY7W.Respositories
{
    /// <summary>
    /// 基本仓储接口定义
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRespository<T> where T : class
    {
        /// <summary>
        /// 查询实体
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        IQueryable<T> Query(Expression<Func<T, bool>> where, bool IsAsNoTracking = true);

        /// <summary>
        /// 新增实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        int Insert(T model);

        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        int Update(T model);


        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="Model"></param>
        /// <returns></returns>
        int Delete(T Model);
    }
}
