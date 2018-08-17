using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MY7W.ModelDto.Dto
{
    public class SysRoleDto
    {
        public Guid Id { get; set; }
        public string RoleName { get; set; }
        public bool State { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
