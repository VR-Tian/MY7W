using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace MY7W.WCFServices
{
    /// <summary>
    /// 用户模块服务
    /// </summary>
    [ServiceContract]
    public interface IUserInfoWcfService
    {
        [OperationContract]
        List<MY7W.ModelDto.UseInfoDto.UserInfo_Alliaction_Dto> ExecuteQuertAll();
    }
}
