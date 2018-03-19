using MY7W.Domain.WebModel;
using MY7W.Respositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MY7W.EntityFrameworkRespository
{
    public class UserInfoRespository : RespositoryBase<MY7W.Domain.WebModel.UserInfo>, IUserInfoRespository
    {
        public UserInfoRespository(MY7W.Datafactory.DatafactoryMamager datafactory) :base(datafactory)
        {

        }
        public List<UserInfo> ExecuteGetDataOfParam(string sqlparam)
        {
            return context.Set<MY7W.Domain.WebModel.UserInfo>().Where(u => sqlparam.Contains(u.Name)).ToList();
        }
    }
}
