using Domain.Entities;
using Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Configurations
{
    public class StockMovementConfiguration: IEntityTypeConfiguration<StockMovement>
    {
        public void Configure(EntityTypeBuilder<StockMovement> builder)
        {
            // FK: StockMovement → Branch
            builder
                .HasOne<Branch>()
                .WithMany()
                .HasForeignKey(b => b.BranchId)
                .OnDelete(DeleteBehavior.Cascade);




            // FK: Product → Branch
            builder
                .HasOne<Product>()
                .WithMany()
                .HasForeignKey(b => b.ProductId)
                .OnDelete(DeleteBehavior.Cascade);


            // FK: CreatedBy → AspNetUsers
            builder
                .HasOne<ApplicationUser>()
                .WithMany()
                .HasForeignKey(b => b.CreatedBy)
                .OnDelete(DeleteBehavior.Restrict);
        }


    }
}
