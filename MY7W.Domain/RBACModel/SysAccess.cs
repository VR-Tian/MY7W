using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MY7W.Domain.RBACModel
{
    public class SysAccess:BaseEntity<Guid>
    {
        public string URL { get; set; }
    }
}
