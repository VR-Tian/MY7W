using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

namespace MY7W.Domain.ModelConfiguration
{
    public class UserInfoConfiguration: EntityTypeConfiguration<MY7W.Domain.WebModel.UserInfo>
    {
        public UserInfoConfiguration()
        {
            ToTable("UserInfo");
        }
    }
}
