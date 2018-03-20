using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
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

        public List<T> ExecuteQuertAll()
        {
            return DBSet.AsNoTracking().ToList();
        }

        public bool ExecuteUpdateModel(T model)
        {
            DBSet.Attach(model);
            Context.Entry(model).State = System.Data.Entity.EntityState.Modified;
            return Context.SaveChanges() > 0;
        }

    }
}
