using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using MY7W.EntityFrameworkRespository;
using MY7W.ModelDto.Dto;
using System.Data.Entity;
using System.Xml;

namespace MY7W.Application
{
    public class UserInfoService
    {
        protected MY7W.Respositories.IUserInfoRespository UserInfoRespository { get; set; }
        protected MY7W.Respositories.IOrderInfoRespository OrderInfoRespository { get; set; }
        public MY7W.Respositories.ISysUserRespository SysUserRespository { get; set; }

        private MY7W.Datafactory.DatafactoryMamager DatafactoryMamager { get; set; }
        public UserInfoService()
        {
            DatafactoryMamager = new Datafactory.DatafactoryMamager(MY7W.Datafactory.DatafactoryMamager.ContextType.MY7WEFDB);
            //Server = new MY7W.EntityFrameworkRespository.UserInfoRespository(DatafactoryMamager);//依赖具体实现
            SysUserRespository = new SysUserRespository(DatafactoryMamager);
            UserInfoRespository = new UserInfoRespository(DatafactoryMamager);
        }

        public async Task<List<MY7W.ModelDto.Dto.UserInfoDto>> ExecuteQuertAllAsync(string id = "")
        {
            return await Task.Run<List<UserInfoDto>>(() => { return ExecuteQuertAll(id); });
        }

        /// <summary>
        /// 根据条件查询实体（未解决动态查询）
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<MY7W.ModelDto.Dto.UserInfoDto> ExecuteQuertAll(string id = "")
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                {
                    CreateEFModelEdmxFile();

                    return UserInfoRespository.Quert(t => t.ID != null).ProjectTo<UserInfoDto>().ToList();
                }
                Guid modelid = Guid.Parse(id);
                var quertValue = UserInfoRespository.Quert(t => t.ID == modelid);
                //foreach (var item in quertValue.ToList())
                //{
                //    var tempsys = item.SysUser;
                //}
                var listValie = quertValue.Include(t => t.SysUser).ProjectTo<UserInfoDto>().ToList();
                return listValie;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ExecuteInsertModel(UserInfoDto model)
        {
            try
            {
                var insetValue = false;
                var newModel = Mapper.Map<UserInfoDto, MY7W.Domain.Model.UserInfo>(model);
                newModel.ID = Guid.NewGuid();
                newModel.CreateTime = DateTime.Now;
                

                newModel.SysUser = new Domain.RBACModel.SysUser() {  ID= Guid.NewGuid(), CreateTime = DateTime.Now, Name = newModel.Name };

                insetValue = UserInfoRespository.Inset(newModel) > 0;
            
                //if (userInfoServer.Inset(newModel))
                //{
                //    OrderInfoServices orderInfoServices = new OrderInfoServices();
                //    orderInfoServices.ExecuteInsertModel(new Domain.Model.OrderInfo() { UserInfoId = newModel.Id, Id = Guid.NewGuid(), CreateTime = DateTime.Now });
                //    //insetValue = orderInfoServer.ExecuteInsetModel(new Domain.Model.OrderInfo() { UserInfoId = newModel.Id, Id = Guid.NewGuid(), CreateTime = DateTime.Now });
                //}
                return insetValue;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ExcuteUpdateModel(UserInfoDto model)
        {
            var newModel = Mapper.Map<MY7W.Domain.Model.UserInfo>(model);
            //TODO：实现更新个别字段
            return UserInfoRespository.Update(newModel) > 0;

        }

        /// <summary>
        /// 创建EF Code First 模式下的映射文件
        /// </summary>
        private void CreateEFModelEdmxFile()
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;

            using (XmlWriter writer = XmlWriter.Create(@"C:\Model.edmx", settings))
            {
                EdmxWriter.WriteEdmx(DatafactoryMamager.DBContext, writer);
            }
        }
    }
}
