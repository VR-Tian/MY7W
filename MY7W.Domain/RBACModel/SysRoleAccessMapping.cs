using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MY7W.Domain.RBACModel
{
    public class SysRoleAccessMapping:BaseEntity<Guid>
    {
        public Guid SysRoleID { get; set; }


        public virtual SysRole  SysRole { get; set; }

        public virtual ICollection<SysAccess>  SysAccesses { get; set; }

    }
}
