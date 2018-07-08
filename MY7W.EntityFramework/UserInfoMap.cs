using MY7W.Domain.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MY7W.EntityFramework
{
    class UserInfoMap : EntityTypeConfiguration<UserInfo>
    {
        public UserInfoMap()
        {
            this.ToTable("UserInfo");
            this.HasKey(t => t.Id);
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Identification).HasColumnName("Identification");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Password).HasColumnName("Password");
            this.Property(t => t.Address).HasColumnName("Address");
            this.Property(t => t.Sys_CreatTime).HasColumnName("Sys_CreatTime");
            this.Property(t => t.Sys_IsDelete).HasColumnName("Sys_IsDelete");
        }
    }
}
