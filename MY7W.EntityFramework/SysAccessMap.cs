using MY7W.Domain.RBACModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MY7W.EntityFramework
{
    public class SysAccessMap:EntityTypeConfiguration<SysAccess>
    {
        public SysAccessMap()
        {
            this.ToTable("SysAccess");
            this.HasKey(t => t.ID);
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.URL).HasColumnName("URL");
            this.Property(t => t.CreateTime).HasColumnName("CreateTime");
            this.Property(t => t.State).HasColumnName("State");


            #region 一对多映射关系
            //this.HasRequired(t => t.SysRoleAccessMapping).
            //      WithMany(t => t.SysAccesses).
            //       HasForeignKey(t => t.SysRoleAccessMappingID).WillCascadeOnDelete();
            #endregion
        }

    }
}
