using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MY7W.Respositories
{
    public interface IRespository<T> where T : class
    {
        IQueryable<T> ExecuteQuertAll(Expression<Func<T, bool>> where);

        bool ExecuteInsetModel(T model);

        bool ExecuteUpdateModel(T model);
    }
}
