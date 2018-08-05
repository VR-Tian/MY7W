using MY7W.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MY7W.Domain.RBACModel
{
    public class SysUser : BaseEntity<Guid>
    {
        public string Name { get; set; }

        //public virtual UserInfo UserInfo { get; set; }

        //public virtual ICollection<SysUserRoleMapping> SysUserRoleMappings { get; set; }
    }
}
