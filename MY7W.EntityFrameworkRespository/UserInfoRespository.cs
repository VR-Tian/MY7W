using AutoMapper;
using MY7W.Domain.Model;
using MY7W.Respositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using System.Data.Entity.Infrastructure;

namespace MY7W.EntityFrameworkRespository
{
    public class UserInfoRespository : RespositoryBase<MY7W.Domain.Model.UserInfo>, IUserInfoRespository
    {
        public UserInfoRespository(MY7W.Datafactory.DatafactoryMamager datafactory) : base(datafactory)
        {

        }

        public DbRawSqlQuery<T> ExecuteQueryBySql<T>(string sql, params SqlParameter[] param)
        {
            return this.ExecuteBy<T>(sql, param);
            //return this.Context.Database.SqlQuery<T>(sql, param);
        }
    }
}
