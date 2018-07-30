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
            this.Property(t => t.SysUserID).HasColumnName("SysUserID").IsOptional();//定义一个外键字段
            this.HasKey(t => t.ID);
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Identification).HasColumnName("Identification");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Password).HasColumnName("Password");
            this.Property(t => t.Address).HasColumnName("Address");
            this.Property(t => t.CreateTime).HasColumnName("CreateTime");
            this.Property(t => t.State).HasColumnName("State");


            #region 为了让权限模块独立出来，在主键类型建立单向一对一关系
            //当在主体类型定义依赖类型的导航属性，且不配置任何关系,将默认使用以下关系
            //this.HasOptional(t => t.SysUser).WithMany();

            //基于外键字段单向一对一
            this.HasRequired(t => t.SysUser).WithRequiredPrincipal().Map(t => t.MapKey("SysUserID"));

            //基于共享主键单向一对一或零
            //this.HasOptional(t => t.SysUser).WithRequired();
            #endregion
        }
    }
}
