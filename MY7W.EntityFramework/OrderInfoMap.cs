using MY7W.Domain.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MY7W.EntityFramework
{
    class OrderInfoMap : EntityTypeConfiguration<OrderInfo>
    {
        public OrderInfoMap()
        {
            this.ToTable("OrderInfo");
            this.HasKey(t => t.ID);
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.UserInfoId).HasColumnName("UserInfoId");
            this.Property(t => t.State).HasColumnName("State");
            this.Property(t => t.CreateTime).HasColumnName("CreateTime");

            //Relationships
            //this.HasRequired(t => t.UserInfo)
            //    .WithMany(t => t.OrderInfo)
            //    .HasForeignKey(t => t.UserInfoId);
        }
    }
}
