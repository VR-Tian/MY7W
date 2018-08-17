using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MY7W.ModelDto.Dto
{
    public class SysAccessDto
    {
        public Guid Id { get; set; }
        public string URL { get; set; }
        public bool State { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
