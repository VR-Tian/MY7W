using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MY7W.WCFServices;

namespace MY7W.Application
{
    public class UserInfoService : MY7W.WCFServices.IUserInfoWcfService
    {
        public MY7W.Respositories.IUserInfoRespository userInfoServer { get; set; }

        private MY7W.Datafactory.DatafactoryMamager DatafactoryMamager { get; set; }
        public UserInfoService()
        {
            DatafactoryMamager = new Datafactory.DatafactoryMamager(MY7W.Datafactory.DatafactoryMamager.ContextType.MY7WEFDB);
            //Server = new MY7W.EntityFrameworkRespository.UserInfoRespository(DatafactoryMamager);//依赖具体实现

            userInfoServer = MY7W.RepositoryFactory.RepositoryFactory.Create(DatafactoryMamager, MY7W.RepositoryFactory.RepositoryFactory.RepositoryType.UserInfoRepository) as MY7W.Respositories.IUserInfoRespository;
        }

        public List<MY7W.ModelDto.UseInfoDto.UserInfo_Alliaction_Dto> ExecuteQuertAll()
        {
            try
            {
                return userInfoServer.ExecuteQuertAll1(x => x.Name != string.Empty);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public bool ExecuteInsertModel(MY7W.ModelDto.UseInfoDto.UserInfo_Alliaction_Dto model)
        {
            try
            {
                var newModel = Mapper.Map<MY7W.ModelDto.UseInfoDto.UserInfo_Alliaction_Dto, MY7W.Domain.Model.UserInfo>(model);
                newModel.Sys_CreatTime = DateTime.Now;
                return userInfoServer.ExecuteInsetModel(newModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


       
        List<MY7W.ModelDto.UseInfoDto.UserInfo_Alliaction_Dto> IUserInfoWcfService.ExecuteQuertAll()
        {
            var temp = ExecuteQuertAll();
            return temp;
        }
    }
}
