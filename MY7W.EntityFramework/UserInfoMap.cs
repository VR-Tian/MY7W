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


            #region 映射关系

            //单向一对一共享主键ID的配置；
            //this.HasRequired(t => t.SysUser).WithRequiredPrincipal()


            //通过外键关联配置有如下两种方式：

            //1：基于依赖对象的外键字段单向一对一（EF的edmx文件显示模型是一对一,数据库的设计却是一对多,这时需要单独把外键字段设置唯一）
            //this.HasRequired(t => t.SysUser).WithRequiredPrincipal().Map(t => t.MapKey("UserID"));
            //疑惑：不允许主体类型单独持久化，这是EF抛出异常：Entities in 'MY7WModel.UserInfo' participate in the 'UserInfo_SysUser' relationship. 0 related 'UserInfo_SysUser_Target' were found. 1 'UserInfo_SysUser_Target' is expected.
            //思考：为了让权限模块独立出来，在主体类型建立单向一对一关系，以上的配置会导致外键ID生成在外键表中，若在依赖实体配置关系，则需要定义主体类型的导航属性，是否会本末倒置。

            //2：参考https://www.cnblogs.com/CreateMyself/p/4742097.html 
            //基于主体对象的外键字段单向一对一（EF的edmx文件显示模型是一对多（数据库关系一致),这时需要单独把外键字段设置唯一，则数据库的关系会变成一对一）
            this.HasRequired(t => t.SysUser).WithMany().HasForeignKey(t => t.SysUserID);//外键字段设置唯一


            //总结：使用第一种方式MapKey映射外键的话，此外键字段是不能被映射到实体；若采用第二种，则HasRequired函数里的类型成为主体类型，也就是主键表。


            //基于共享主键单向一对一或零
            //this.HasOptional(t => t.SysUser).WithRequired();
            #endregion
        }
    }
}
