using Domain.Entities;
using Infrastructure.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {

            //  FK: Product → Category
            builder
                .HasOne<Category>()
                .WithMany()
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);


            //  FK: CategoryType → Category
            builder
                .HasOne<CategoryType>()
                .WithMany()
                .HasForeignKey(p => p.CategoryTypeId)
                .OnDelete(DeleteBehavior.Cascade);

            //  FK: CreatedBy → AspNetUsers
            builder
                .HasOne<ApplicationUser>()
                .WithMany()
                .HasForeignKey(p => p.CreatedBy)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
