using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MY7W.Application
{
    public class UserInfoService
    {
        public MY7W.Respositories.IRespository<MY7W.Domain.WebModel.UserInfo> Context { get; set; }
        public UserInfoService()
        {
            Context = new EntityFrameworkRespository.UserInfoRespository();
        }

        public List<MY7W.Domain.WebModel.UserInfo> ExecuteQuertAll()
        {
            try
            {
                return Context.ExecuteQuertAll();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
