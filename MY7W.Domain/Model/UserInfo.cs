using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MY7W.Domain.Model
{
    public class UserInfo
    {
        public UserInfo()
        {
            this.OrderInfo = new HashSet<OrderInfo>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string Identification { get; set; }
        public bool Sys_IsDelete { get; set; }
        public DateTime Sys_CreatTime { get; set; }
        public virtual ICollection<OrderInfo> OrderInfo { get; set; }
    }
}
