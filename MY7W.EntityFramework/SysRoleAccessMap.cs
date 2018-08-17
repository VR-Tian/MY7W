using MY7W.Domain.RBACModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MY7W.EntityFramework
{
    public class SysRoleAccessMap : EntityTypeConfiguration<SysRoleAccessMapping>
    {
        public SysRoleAccessMap()
        {
            this.ToTable("SysRoleAccessMapping");
            this.HasKey(t => t.ID);
            this.Property(t => t.SysRoleID).HasColumnName("SysRoleID");
            this.Property(t => t.CreateTime).HasColumnName("CreateTime");
            this.Property(t => t.State).HasColumnName("State");

            #region 一对多映射关系
            this.HasRequired(t => t.SysRole).WithMany().HasForeignKey(t => t.SysRoleID).WillCascadeOnDelete();

            this.HasRequired(t => t.SysAccess).WithMany().HasForeignKey(t => t.SysAccessID).WillCascadeOnDelete();

            #endregion
        }
    }
}
