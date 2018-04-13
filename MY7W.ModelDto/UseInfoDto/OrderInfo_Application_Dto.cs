using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MY7W.ModelDto.UseInfoDto
{
    public class OrderInfo_Application_Dto
    {
        //public OrderInfo_Application_Dto()
        //{
        //    this.UserInfo = new UserInfo_Alliaction_Dto();
        //}
       
        public Guid Id { get; set; }
        public DateTime CreateTime { get; set; }
        public bool IsDelete { get; set; }
        public Guid UserInfoId { get; set; }
        public OrderInfo_User_Alliaction_Dto UserInfo1 { get; set; }
        public MY7W.ModelDto.UseInfoDto.UserInfo_Alliaction_Dto UserInfo { get; set; }

        public class OrderInfo_User_Alliaction_Dto
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
            public string Password { get; set; }
            public string Address { get; set; }
            public string Identification { get; set; }
            public virtual MY7W.ModelDto.UseInfoDto.UserInfo_Alliaction_Dto UserInfo { get; set; }
        }
    }
}
