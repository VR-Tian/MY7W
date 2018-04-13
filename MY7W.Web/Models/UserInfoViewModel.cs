using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MY7W.Web.Models
{
    public class UserInfoViewModel
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Identification { get; set; }
    }
}