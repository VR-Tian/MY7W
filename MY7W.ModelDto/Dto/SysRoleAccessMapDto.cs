using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MY7W.ModelDto.Dto
{
    public class SysRoleAccessMapDto
    {
        public Guid Id { get; set; }
        public Guid SysRoleID { get; set; }
        public Guid SysAccessID { get; set; }
        public bool State { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
