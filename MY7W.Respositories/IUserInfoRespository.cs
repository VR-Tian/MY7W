using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MY7W.Respositories
{
    public interface IUserInfoRespository: IRespository<MY7W.Domain.Model.UserInfo>
    {

        List<MY7W.ModelDto.UseInfoDto.UserInfo_Alliaction_Dto> ExecuteQuertAll1(Expression<Func<MY7W.Domain.Model.UserInfo, bool>> where);
    }
}
