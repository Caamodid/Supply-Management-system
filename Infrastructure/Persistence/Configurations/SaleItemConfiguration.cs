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
    public class SaleItemConfiguration : IEntityTypeConfiguration<SaleItem>
    {

        public void Configure(EntityTypeBuilder<SaleItem> builder)
        {
            // FK: SaleItem → sales
            builder
                .HasOne<Sale>()
                .WithMany()
                .HasForeignKey(b => b.SaleId)
                .OnDelete(DeleteBehavior.Cascade);


            // FK: SaleItem → product
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
