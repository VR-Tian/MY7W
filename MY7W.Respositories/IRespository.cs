using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MY7W.Respositories
{
    public interface IRespository<T> where T : class
    {
        List<T> ExecuteQuertAll();

        bool ExecuteInsetModel(T model);

        bool ExecuteUpdateModel(T model);
    }
}
