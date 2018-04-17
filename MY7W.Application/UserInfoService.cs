using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MY7W.WCFServices;
using AutoMapper.QueryableExtensions;
using System.Threading;
using System.IO;

namespace MY7W.Application
{
    public class UserInfoService : MY7W.WCFServices.IUserInfoWcfService
    {
        public MY7W.Respositories.IUserInfoRespository userInfoServer { get; set; }
        public MY7W.Respositories.IOrderInfoRespository orderInfoServer { get; set; }

        private MY7W.Datafactory.DatafactoryMamager DatafactoryMamager { get; set; }
        public UserInfoService()
        {
            DatafactoryMamager = new Datafactory.DatafactoryMamager(MY7W.Datafactory.DatafactoryMamager.ContextType.MY7WEFDB);
            //Server = new MY7W.EntityFrameworkRespository.UserInfoRespository(DatafactoryMamager);//依赖具体实现

            orderInfoServer = MY7W.RepositoryFactory.RepositoryFactory.Create(DatafactoryMamager, MY7W.RepositoryFactory.RepositoryFactory.RepositoryType.OrderInfoRepository) as MY7W.Respositories.IOrderInfoRespository;

            userInfoServer = MY7W.RepositoryFactory.RepositoryFactory.Create(DatafactoryMamager, MY7W.RepositoryFactory.RepositoryFactory.RepositoryType.UserInfoRepository) as MY7W.Respositories.IUserInfoRespository;
        }

        public async Task<List<MY7W.ModelDto.UseInfoDto.UserInfo_Alliaction_Dto>> ExecuteQuertAllAsync(string id = "")
        {
           return await Task.Run<List<MY7W.ModelDto.UseInfoDto.UserInfo_Alliaction_Dto>>(() => { return ExecuteQuertAll(id); });
        }

        public List<MY7W.ModelDto.UseInfoDto.UserInfo_Alliaction_Dto> ExecuteQuertAll(string id = "")
        {
            try
            {
                //var sqlvalue = userInfoServer.ExecuteQueryBySql<MY7W.ModelDto.UseInfoDto.UserInfo_Alliaction_Dto>("select * from UserInfoes").ToList();

                if (string.IsNullOrEmpty(id))
                {
                    return userInfoServer.ExecuteQuertAll(x => x.Id != null).ProjectTo<MY7W.ModelDto.UseInfoDto.UserInfo_Alliaction_Dto>().ToList();
                }
                Guid modelid = Guid.Parse(id);
                return userInfoServer.ExecuteQuertAll(x => x.Id == modelid).ProjectTo<MY7W.ModelDto.UseInfoDto.UserInfo_Alliaction_Dto>().ToList();
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
                var insetValue = true;
                var newModel = Mapper.Map<MY7W.ModelDto.UseInfoDto.UserInfo_Alliaction_Dto, MY7W.Domain.Model.UserInfo>(model);
                newModel.Id = Guid.NewGuid();
                newModel.Sys_CreatTime = DateTime.Now;

                if (userInfoServer.ExecuteInsetModel(newModel))
                {
                    insetValue = orderInfoServer.ExecuteInsetModel(new Domain.Model.OrderInfo() { UserInfoId = newModel.Id, Id = Guid.NewGuid(), CreateTime = DateTime.Now });
                }
                return insetValue;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> ExcuteUpdateModel(MY7W.ModelDto.UseInfoDto.UserInfo_Alliaction_Dto model)
        {
            var newModel = Mapper.Map<MY7W.Domain.Model.UserInfo>(model);

            Thread.Sleep(int.Parse(newModel.Identification));
            var temp =  await userInfoServer.ExecuteTranUpdate(newModel);
            return temp;
        }



        List<MY7W.ModelDto.UseInfoDto.UserInfo_Alliaction_Dto> IUserInfoWcfService.ExecuteQuertAll()
        {
            var temp = ExecuteQuertAll();
            return temp;
        }
    }
}
