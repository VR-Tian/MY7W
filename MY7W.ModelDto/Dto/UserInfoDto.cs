using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MY7W.ModelDto.Dto
{
    public class UserInfoDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string Identification { get; set; }
        public bool State { get; set; }
        

        public Guid SysUserID { get; set; }
        public bool SysUserState { get; set; }
        /// <summary>
        /// 若此属性处于工作中，通过AutpMapper拓展IQueryable使用映射类型去查询数据时，此时的不存在延迟加载功能(循环加载与此实体的导航属性的实体)
        /// </summary>
        //public ICollection<MY7W.ModelDto.UseInfoDto.OrderInfo_Application_Dto> OrderInfo { get; set; }
    }
}
