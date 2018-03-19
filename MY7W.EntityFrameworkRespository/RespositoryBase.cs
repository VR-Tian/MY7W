using System;
using System.Collections.Generic;
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
        protected readonly MY7W.EntityFramework.MY7WModel context;
        public RespositoryBase()
        {
            context = new EntityFramework.MY7WModel();
        }
        /// <summary>
        /// Add model
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool ExecuteInsetModel(T model)
        {
            context.Set<T>().Add(model);
            return context.SaveChanges() > 0;
        }

        public List<T> ExecuteQuertAll()
        {
            return context.Set<T>().AsNoTracking().ToList();
        }

        public bool ExecuteUpdateModel(T model)
        {
            context.Set<T>().Attach(model);
            context.Entry(model).State = System.Data.Entity.EntityState.Modified;
            return context.SaveChanges() > 0;
        }

    }
}
