using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MY7W.Application
{
    public class OrderInfoServices
    {
        public MY7W.Respositories.IOrderInfoRespository Server { get; set; }
        private MY7W.Datafactory.DatafactoryMamager DatafactoryMamager { get; set; }
        public OrderInfoServices()
        {
            DatafactoryMamager = new Datafactory.DatafactoryMamager(MY7W.Datafactory.DatafactoryMamager.ContextType.MY7WEFDB);
            Server = new MY7W.EntityFrameworkRespository.OrderInfoRespository(DatafactoryMamager);
        }

        public List<MY7W.Domain.WebModel.OrderInfo> ExecuteQuertAll()
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


        public bool ExecuteInsertModel(MY7W.Domain.WebModel.OrderInfo model)
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


        public List<MY7W.Domain.WebModel.OrderInfo> ExecuteGetDataOfParam(Expression<Func<MY7W.Domain.WebModel.OrderInfo, bool>> where)
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
