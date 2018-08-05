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
            this.HasKey(t => t.ID);
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Identification).HasColumnName("Identification");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Password).HasColumnName("Password");
            this.Property(t => t.Address).HasColumnName("Address");
            this.Property(t => t.CreateTime).HasColumnName("CreateTime");
            this.Property(t => t.State).HasColumnName("State");


            #region 为了让权限模块独立出来，在主体类型建立单向一对一关系
            //当在主体类型定义依赖类型的导航属性，且不配置任何关系,将默认使用以下关系
            //this.HasOptional(t => t.SysUser).WithMany();

            //基于依赖对象的外键字段单向一对一（EF的edmx文件显示模型是一对一,数据库的设计却是一对多,这时需要单独把外键字段设置唯一）
            //疑惑：不允许主体类型单独持久化，错误显示：Entities in 'MY7WModel.UserInfo' participate in the 'UserInfo_SysUser' relationship. 0 related 'UserInfo_SysUser_Target' were found. 1 'UserInfo_SysUser_Target' is expected.
            //this.HasRequired(t => t.SysUser).WithRequiredPrincipal().Map(t => t.MapKey("UserID"));

            //参考https://www.cnblogs.com/CreateMyself/p/4742097.html 
            //基于主体对象的外键字段单向一对一（EF的edmx文件显示模型是一对多（数据库关系一致),这时需要单独把外键字段设置唯一，这时数据库的关系会变成一对一）
            this.HasRequired(t => t.SysUser).WithMany().HasForeignKey(t => t.SysUserID);

            //基于共享主键单向一对一或零
            //this.HasOptional(t => t.SysUser).WithRequired();
            #endregion
        }
    }
}
