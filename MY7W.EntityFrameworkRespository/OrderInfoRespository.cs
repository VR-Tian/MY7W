using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MY7W.Datafactory;

namespace MY7W.EntityFrameworkRespository
{
    public class OrderInfoRespository : RespositoryBase<MY7W.Domain.WebModel.OrderInfo>, MY7W.Respositories.IOrderInfoRespository
    {
        public OrderInfoRespository(DatafactoryMamager datafactory) : base(datafactory)
        {

        }
    }
}
