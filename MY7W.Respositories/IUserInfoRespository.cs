using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MY7W.Respositories
{
    public interface IUserInfoRespository: IRespository<MY7W.Domain.Model.UserInfo>
    {
        DbRawSqlQuery<T> ExecuteQueryBySql<T>(string sql, params SqlParameter[] param);
    }
}
