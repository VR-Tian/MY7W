using MY7W.Domain.RBACModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MY7W.EntityFramework
{
    public class SysUserRoleMap : EntityTypeConfiguration<SysUserRoleMapping>
    {
        public SysUserRoleMap()
        {
            this.ToTable("SysUserRoleMapping");
            this.HasKey(t => t.ID);
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.SysUserID).HasColumnName("SysUserID");
            this.Property(t => t.SysRoleID).HasColumnName("SysRoleID");
            this.Property(t => t.CreateTime).HasColumnName("CreateTime");
            this.Property(t => t.State).HasColumnName("State");

            #region 映射与主键表的外键关系
            //TODO：在主键实体如果声明外建表的实体集合（ICollection），code frist模式下，会根据成员关系默认使用映射关系(如下映射一对多关系可以省略)
            //this.HasRequired(t => t.SysUser).
            //    WithMany(t => t.SysUserRoleMappings).
            //     HasForeignKey(t => t.SysUserID).WillCascadeOnDelete();

            
            #endregion
        }
    }
}
