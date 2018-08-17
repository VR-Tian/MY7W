using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MY7W.EntityFrameworkRespository
{
    public class RespositoryBase<T> where T : class
    {
        ////TODO:更新部分字段如何实现

        /// <summary>
        ///当前实例上下文
        /// </summary>
        protected DbContext Context { get; private set; }
        /// <summary>
        /// 当前实体类型
        /// </summary>
        public DbSet<T> Entitys { get; private set; }

        public RespositoryBase(MY7W.Datafactory.DatafactoryMamager datafactory)
        {
            Context = datafactory.DBContext;
            Entitys = Context.Set<T>();
        }
  
        public int Insert(T model)
        {
            Entitys.Add(model);
            return Context.SaveChanges();
        }

        public int Delete(T model)
        {
            Entitys.Attach(model);
            Context.Entry(model).State = System.Data.Entity.EntityState.Deleted;
            return Context.SaveChanges();
        }

        public int Update(T model)
        {
            Entitys.Attach(model);
            Context.Entry(model).State = System.Data.Entity.EntityState.Modified;
            return Context.SaveChanges();
        }

        /// <summary>
        /// 查询（默认放弃跟踪）
        /// </summary>
        /// <param name="where">条件</param>
        /// <param name="IsAsNoTracking">是否放弃跟踪</param>
        /// <returns></returns>
        public virtual IQueryable<T> Query(Expression<Func<T, bool>> where,bool IsAsNoTracking=true)
        {
            if (IsAsNoTracking)
            {
                var value= Entitys.Where(where).AsNoTracking();
                return value;
            }
            return Entitys.Where(where);
        }

        public async Task<bool> ExecuteTranUpdate(T model)
        {
            var temp = typeof(T);
            var modelProperties = temp.GetProperties();
            Entitys.Attach(model);
            foreach (var item in modelProperties)
            {
              
                var modelvalue = item.GetValue(model);
                if (modelvalue != null && modelvalue.GetType().GenericTypeArguments.Count() == 0)
                {
                    Context.Entry(model).Property(item.Name).IsModified = true;
                }
            }
            var excuteValue = await Context.SaveChangesAsync();
            return excuteValue > 0;
        }
        /// <summary>
        /// 返回无跟踪状态的全部数据
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<T> GetAll()
        {
            return Entitys.AsNoTracking();
        }

        /// <summary>
        /// SQL参数化延迟查询
        /// </summary>
        /// <param name="t"></param>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public virtual DbRawSqlQuery<T0> ExecuteBy<T0>(string sql, params SqlParameter[] parameters)
        {
            this.Context.Database.CommandTimeout = 120;
            return Context.Database.SqlQuery<T0>(sql, parameters);
        }
    }
}
