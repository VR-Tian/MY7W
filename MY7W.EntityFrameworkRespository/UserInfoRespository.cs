using AutoMapper;
using MY7W.Domain.Model;
using MY7W.Respositories;
using MY7W.Tools;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MY7W.EntityFrameworkRespository
{
    public class UserInfoRespository : RespositoryBase<MY7W.Domain.Model.UserInfo>, IUserInfoRespository
    {
        public UserInfoRespository(MY7W.Datafactory.DatafactoryMamager datafactory) : base(datafactory)
        {

        }

        public List<MY7W.ModelDto.UseInfoDto.UserInfo_Alliaction_Dto> ExecuteQuertAll1(Expression<Func<UserInfo, bool>> where)
        {
            //return base.ExecuteQuertAll(where);
            var temp = this.DBSet.Where(where).Project().To<MY7W.ModelDto.UseInfoDto.UserInfo_Alliaction_Dto>().ToList();
            //Mapper.Map<IEnumerable<MY7W.Domain.Model.UserInfo>, IEnumerable<MY7W.ModelDto.UseInfoDto.UserInfo_Alliaction_Dto>>(this.DBSet).ToList();//缓存级别转换DTO
            return temp;
        }
    }
}
