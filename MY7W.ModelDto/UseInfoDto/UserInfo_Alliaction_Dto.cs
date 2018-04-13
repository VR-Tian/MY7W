using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MY7W.ModelDto.UseInfoDto
{
    public class UserInfo_Alliaction_Dto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string Identification { get; set; }
        public virtual ICollection<MY7W.ModelDto.UseInfoDto.OrderInfo_Application_Dto> OrderInfo { get; set; }
    }
}
