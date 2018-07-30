using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MY7W.Domain.RBACModel
{
    public class SysUserRoleMapping : BaseEntity<Guid>
    {
        public Guid SysUserID { get; set; }

        public Guid SysRoleID { get; set; }

        //public virtual SysUser SysUser { get; set; }

        //public virtual SysRole SysRole { get; set; }

    }
}
