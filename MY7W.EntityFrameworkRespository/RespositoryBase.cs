﻿using System;
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

        /// <summary>
        ///当前实例上下文
        /// </summary>
        protected DbContext Context { get; private set; }
        protected DbSet<T> DBSet { get; private set; }
        public RespositoryBase(MY7W.Datafactory.DatafactoryMamager datafactory)
        {

            //context = new EntityFramework.MY7WModel();
            Context = datafactory.dbContext;
            DBSet = Context.Set<T>();
        }
        /// <summary>
        /// Add model
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool ExecuteInsetModel(T model)
        {
            DBSet.Add(model);
            return Context.SaveChanges() > 0;
        }

        public virtual IQueryable<T> ExecuteQuertAll(Expression<Func<T, bool>> where)
        {
            return DBSet.Where(where).AsNoTracking();
        }

        public bool ExecuteUpdateModel(T model)
        {
            DBSet.Attach(model);
            Context.Entry(model).State = System.Data.Entity.EntityState.Modified;
            return Context.SaveChanges() > 0;
        }

        public async Task<bool> ExecuteTranUpdate(T model)
        {
            var tran = this.Context.Database.BeginTransaction();
            var temp = typeof(T);
            var modelProperties = temp.GetProperties();
            DBSet.Attach(model);
            foreach (var item in modelProperties)
            {
                //if (item.PropertyType.IsPrimitive)
                //{
                //    continue;
                //}
                var modelvalue = item.GetValue(model);
                if (modelvalue != null && modelvalue.GetType().GenericTypeArguments.Count() == 0)
                {
                    Context.Entry(model).Property(item.Name).IsModified = true;
                }
            }
            tran.Commit();
            var excuteValue = await Context.SaveChangesAsync();
            return excuteValue > 0;
        }
        /// <summary>
        /// 返回无跟踪状态的全部数据
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<T> GetAll()
        {
            return DBSet.AsNoTracking();
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
