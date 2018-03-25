using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MY7W.Domain.WebModel
{
    public class OrderInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public Guid UsersID { get; set; }
        public DateTime CreateTime { get; set; }
        public bool IsDelete { get; set; }
        //[ForeignKey("UsersId")]
        //public UserInfo User { get; set; }
    }
}
