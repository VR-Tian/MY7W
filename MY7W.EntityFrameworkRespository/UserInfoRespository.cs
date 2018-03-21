using MY7W.Domain.WebModel;
using MY7W.Respositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    }
}
