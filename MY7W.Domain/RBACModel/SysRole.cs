using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MY7W.Domain.RBACModel
{
    public class SysRole : BaseEntity<Guid>
    {
        public string RoleName { get; set; }
    }
}
