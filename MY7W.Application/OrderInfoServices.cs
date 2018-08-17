using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using MY7W.EntityFrameworkRespository;

namespace MY7W.Application
{
    public class OrderInfoServices
    {
        public MY7W.Respositories.IOrderInfoRespository Server { get; set; }
        private MY7W.Datafactory.DatafactoryMamager DatafactoryMamager { get; set; }
        public OrderInfoServices()
        {
            DatafactoryMamager = new Datafactory.DatafactoryMamager(MY7W.Datafactory.DatafactoryMamager.ContextType.MY7WEFDB);

            //Server = MY7W.RepositoryFactory.RepositoryFactory.Create(DatafactoryMamager, MY7W.RepositoryFactory.RepositoryFactory.RepositoryType.OrderInfoRepository) as MY7W.Respositories.IOrderInfoRespository;
            Server = new OrderInfoRespository(DatafactoryMamager);
        }

        public List<MY7W.ModelDto.Dto.OrderInfoDto> ExecuteQuertAll(Guid id)
        {
            //try
            //{
            //    return Server.Quert(T => T.UserInfoId == id).ProjectTo<MY7W.ModelDto.UseInfoDto.OrderInfo_Application_Dto>().ToList();
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
            return null;
        }


        public bool ExecuteInsertModel(MY7W.Domain.Model.OrderInfo model)
        {
            throw new Exception();
        }


        public List<MY7W.Domain.Model.OrderInfo> ExecuteGetDataOfParam(Expression<Func<MY7W.Domain.Model.OrderInfo, bool>> where)
        {
            try
            {
                return Server.Query(where).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
