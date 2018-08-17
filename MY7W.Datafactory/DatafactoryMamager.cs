using System;
using System.Data.Entity;
using System.Transactions;
using System.Web;

namespace MY7W.Datafactory
{
    /// <summary>
    /// Db上下文工厂
    /// </summary>
    public class DatafactoryMamager
    {
        public enum ContextType
        {
            MY8BEFDB,
            MY7WEFDB,
        }

        public DatafactoryMamager(ContextType contextType)
        {
            if (contextType == ContextType.MY7WEFDB)
            {
                var context = HttpContext.Current.Items[ContextType.MY7WEFDB.ToString()] as DbContext;
                if (context == null)
                {
                    context = new MY7W.EntityFramework.MY7WModel();
                    HttpContext.Current.Items[ContextType.MY7WEFDB.ToString()] = context;
                }
                DBContext = context;

                //var context = HttpContext.Current.Cache.Get(ContextType.MY7WEFDB.ToString()) as DbContext;
                //if (context == null)
                //{
                //    context = new MY7W.EntityFramework.MY7WModel();
                //    HttpContext.Current.Cache.Insert(ContextType.MY7WEFDB.ToString(), context);
                //}
                //DBContext = context;
            }
        }

        public DbContext DBContext { get; private set; }
    }
}
