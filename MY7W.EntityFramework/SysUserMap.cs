using MY7W.Domain.RBACModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MY7W.EntityFramework
{
    public class SysUserMap: EntityTypeConfiguration<SysUser>
    {
        public SysUserMap()
        {
            this.ToTable("SysUser");
            this.HasKey(t => t.ID);
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.CreateTime).HasColumnName("CreateTime");
            this.Property(t => t.State).HasColumnName("State");

            #region  映射与主键表的外键关系：
            //this.HasRequired(t => t.UserInfo).WithRequiredDependent();

            //this.HasMany(t => t.SysUserRoleMappings).
            //   WithRequired().HasForeignKey(t => t.SysUserID);
            #endregion

        }
    }
}
