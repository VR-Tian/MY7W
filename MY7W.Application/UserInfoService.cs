using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MY7W.Domain.ModelMap;
using MY7W.WCFServices;

namespace MY7W.Application
{
    public class UserInfoService : MY7W.WCFServices.IUserInfoWcfService
    {
        public MY7W.Respositories.IUserInfoRespository Server { get; set; }
        private MY7W.Datafactory.DatafactoryMamager DatafactoryMamager { get; set; }
        public UserInfoService()
        {
            DatafactoryMamager = new Datafactory.DatafactoryMamager(MY7W.Datafactory.DatafactoryMamager.ContextType.MY7WEFDB);
            Server = new MY7W.EntityFrameworkRespository.UserInfoRespository(DatafactoryMamager);
        }

        public List<MY7W.Domain.Model.UserInfo> ExecuteQuertAll()
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


        public bool ExecuteInsertModel(MY7W.Domain.Model.UserInfo model)
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


        public List<MY7W.Domain.Model.UserInfo> ExecuteGetDataOfParam(Expression<Func<MY7W.Domain.Model.UserInfo, bool>> where)
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

        List<UserInfoDto> IUserInfoWcfService.ExecuteQuertAll()
        {
            var temp = ExecuteQuertAll();
            return Mapper.Map<List<MY7W.Domain.ModelMap.UserInfoDto>>(temp);
        }
    }
}
