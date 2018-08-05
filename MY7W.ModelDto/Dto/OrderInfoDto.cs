using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MY7W.ModelDto.Dto
{
    public class OrderInfoDto
    {
        //public OrderInfo_Application_Dto()
        //{
        //    this.UserInfo = new UserInfo_Alliaction_Dto();
        //}
       
        public Guid Id { get; set; }
        public DateTime CreateTime { get; set; }
        public bool IsDelete { get; set; }
        public Guid UserInfoId { get; set; }

    }
}
