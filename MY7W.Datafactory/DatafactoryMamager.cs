using System;
using System.Activities.Statements;
using System.Data.Entity;

namespace MY7W.Datafactory
{
    public class DatafactoryMamager: Disposable
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
                dbContext = new MY7W.EntityFramework.MY7WModel();
            }
        }

        public DbContext dbContext { get; private set; }

        

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
        //public void Commit(bool isTransaction)
        //{
        //    #region 事物提交
        //    using (TransactionScope scope = new TransactionScope())
        //    {
        //        this.Commit();
        //        //dataContext.SaveChanges();
        //        scope.Complete();
        //    }
        //    #endregion
        //}


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
