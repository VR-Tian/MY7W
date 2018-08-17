namespace MY7W.EntityFramework
{
    using MY7W.Domain.Model;
    using MY7W.Domain.RBACModel;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class MY7WModel : DbContext
    {
        //您的上下文已配置为从您的应用程序的配置文件(App.config 或 Web.config)
        //使用“MY7WModel”连接字符串。默认情况下，此连接字符串针对您的 LocalDb 实例上的
        //“MY7W.EntityFramework.MY7WModel”数据库。
        // 
        //如果您想要针对其他数据库和/或数据库提供程序，请在应用程序配置文件中修改“MY7WModel”
        //连接字符串。
        public MY7WModel()
            : base("name=MY7WModel")
        {
            // Database.SetInitializer<MY7WModel>(new DropCreateDatabaseAlways<MY7WModel>());
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserInfoMap());
            //modelBuilder.Configurations.Add(new OrderInfoMap());
            modelBuilder.Configurations.Add(new SysUserMap());
            ///TODO:注释情况下，如果此模型与另一个模型(正常使用)存在定义引用情况下，仍会在数据库生成对应的表,但迁移表没有记录此模型的定义
            modelBuilder.Configurations.Add(new SysUserRoleMap());
            modelBuilder.Configurations.Add(new SysRoleMap());
            modelBuilder.Configurations.Add(new SysRoleAccessMap());
            modelBuilder.Configurations.Add(new SysAccessMap());
            base.OnModelCreating(modelBuilder);
        }

        //为您要在模型中包含的每种实体类型都添加 DbSet。有关配置和使用 Code First  模型
        //的详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=390109。

        public virtual DbSet<UserInfo> UserInfo { get; set; }
        public virtual DbSet<SysUser> SysUser { get; set; }
        public virtual DbSet<SysUserRoleMapping> SysUserRoleMapping { get; set; }
        public virtual DbSet<SysRole> SysRole { get; set; }
        public virtual DbSet<SysRoleAccessMapping> SysRoleAccessMapping { get; set; }
        public virtual DbSet<SysAccess> SysAccesses { get; set; }
        //public virtual DbSet<OrderInfo> OrderInfo { get; set; }
    }


}