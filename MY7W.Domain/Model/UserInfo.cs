using MY7W.Domain.RBACModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MY7W.Domain.Model
{
    public class UserInfo : BaseEntity<Guid>
    {
        public UserInfo()
        {
            ID = Guid.NewGuid();
        }

        public string Name { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string Identification { get; set; }


        public Guid SysUserID { get; set; }
        public virtual SysUser SysUser { get; set; }
        //public virtual ICollection<OrderInfo> OrderInfo { get; set; }
    }
}
