using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MY7W.Application
{
    public class UserInfoService
    {
        public MY7W.Respositories.IUserInfoRespository Context { get; set; }
        private MY7W.Datafactory.DatafactoryMamager DatafactoryMamager { get; set; }
        public UserInfoService()
        {
            DatafactoryMamager = new Datafactory.DatafactoryMamager(MY7W.Datafactory.DatafactoryMamager.ContextType.MY7WEFDB);
            //Context = new EntityFrameworkRespository.UserInfoRespository();
            Context = new MY7W.EntityFrameworkRespository.UserInfoRespository(DatafactoryMamager);
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


        public List<MY7W.Domain.WebModel.UserInfo> ExecuteGetDataOfParam(string name)
        {
            try
            {
                return Context.ExecuteGetDataOfParam(name);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
