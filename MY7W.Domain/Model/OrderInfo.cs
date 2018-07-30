using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MY7W.Domain.Model
{
    public class OrderInfo : BaseEntity<Guid>
    {

        public OrderInfo()
        {
            ID = Guid.NewGuid();
        }

        public Guid UserInfoId { get; set; }
        public virtual UserInfo UserInfo { get; set; }

    }
}
