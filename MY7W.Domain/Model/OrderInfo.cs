using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MY7W.Domain.Model
{
    public class OrderInfo
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public DateTime CreateTime { get; set; }
        public bool IsDelete { get; set; }
        public Guid UserInfoId { get; set; }
        //[ForeignKey("UserInfoId")]
        public virtual UserInfo UserInfo { get; set; }

    }
}
