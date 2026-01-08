//using Infrastructure.Identity;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Infrastructure.Persistence.Configurations
//{
//    public class RolePermissionConfiguration : IEntityTypeConfiguration<RolePermission>
//    {
//        //public void Configure(EntityTypeBuilder<RolePermission> builder)
//        //{
//        //    builder.HasKey(rp => rp.Id);

//        //    builder.Property(rp => rp.Permission)
//        //           .IsRequired()
//        //           .HasMaxLength(200);

//        //    builder
//        //        .HasOne(rp => rp.Role)
//        //        .WithMany(r => r.RolePermissions)
//        //        .HasForeignKey(rp => rp.RoleId)
//        //        .OnDelete(DeleteBehavior.Cascade);
//        //}
//    }
//}
