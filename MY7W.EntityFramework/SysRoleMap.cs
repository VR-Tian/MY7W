using MY7W.Domain.RBACModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MY7W.EntityFramework
{
    public class SysRoleMap: EntityTypeConfiguration<SysRole>
    {
        public SysRoleMap()
        {
            this.ToTable("SysRole");
            this.HasKey(t => t.ID);
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.CreateTime).HasColumnName("CreateTime");
            this.Property(t => t.State).HasColumnName("State");

            #region 映射与系统用户中间表关系
           
            #endregion
        }
    }
}
