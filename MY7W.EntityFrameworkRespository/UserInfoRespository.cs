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

namespace MY7W.EntityFrameworkRespository
{
    public class UserInfoRespository : RespositoryBase<MY7W.Domain.Model.UserInfo>, IUserInfoRespository
    {
        public UserInfoRespository(MY7W.Datafactory.DatafactoryMamager datafactory) : base(datafactory)
        {

        }
    }
}
