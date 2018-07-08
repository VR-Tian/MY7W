using System;
using System.Data.Entity;
using System.Transactions;
using System.Web;

namespace MY7W.Datafactory
{
    public class DatafactoryMamager: Disposable, IDatabaseFactory
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
                dbContext = context;

                //var context = HttpContext.Current.Cache.Get(ContextType.MY7WEFDB.ToString()) as DbContext;
                //if (context == null)
                //{
                //    context = new MY7W.EntityFramework.MY7WModel();
                //    HttpContext.Current.Cache.Insert(ContextType.MY7WEFDB.ToString(), context);
                //}
                //dbContext = context;
            }
        }

        public DbContext dbContext { get; private set; }

        protected override void DisposeCore()
        {
            base.DisposeCore();
            dbContext.Dispose();
        }

        /// <summary>
        /// 单元提交
        /// </summary>
        public void Commit()
        {
            dbContext.SaveChanges();
        }

        /// <summary>
        /// 单元提交事物提交
        /// </summary>
        public void Commit(bool isTransaction)
        {
            #region 事物提交
            using (TransactionScope scope = new TransactionScope())
            {
                this.Commit();
                //dataContext.SaveChanges();
                scope.Complete();
            }
            #endregion
        }
      

    }
    public interface IDatabaseFactory: IDisposable
    {
        void Commit();
        void Commit(bool isTransaction);
    }


    public class Disposable : IDisposable
    {
        private bool isDisposed;

        ~Disposable()
        {
            Dispose(true);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private void Dispose(bool disposing)
        {
            if (!isDisposed && disposing)
            {
                DisposeCore();
            }

            isDisposed = true;
        }

        protected virtual void DisposeCore()
        {

        }
    }
}
