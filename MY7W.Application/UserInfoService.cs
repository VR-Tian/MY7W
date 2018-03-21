using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MY7W.Application
{
    public class UserInfoService
    {
        public MY7W.Respositories.IUserInfoRespository Server { get; set; }
        private MY7W.Datafactory.DatafactoryMamager DatafactoryMamager { get; set; }
        public UserInfoService()
        {
            DatafactoryMamager = new Datafactory.DatafactoryMamager(MY7W.Datafactory.DatafactoryMamager.ContextType.MY7WEFDB);
            //Context = new EntityFrameworkRespository.UserInfoRespository();
            Server = new MY7W.EntityFrameworkRespository.UserInfoRespository(DatafactoryMamager);
        }

        public List<MY7W.Domain.WebModel.UserInfo> ExecuteQuertAll()
        {
            try
            {
                return Server.ExecuteQuertAll(T => T.Id != null).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public bool ExecuteInsertModel(MY7W.Domain.WebModel.UserInfo model)
        {
            try
            {
                return Server.ExecuteInsetModel(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<MY7W.Domain.WebModel.UserInfo> ExecuteGetDataOfParam(Expression<Func<MY7W.Domain.WebModel.UserInfo, bool>> where)
        {
            try
            {
                return Server.ExecuteQuertAll(where).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
