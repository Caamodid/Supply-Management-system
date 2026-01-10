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
    public class CategoryTypeConfiguration : IEntityTypeConfiguration<CategoryType>
    {

        public void Configure(EntityTypeBuilder<CategoryType> builder)
        {
            // FK: CategoryType → Category
            builder
                .HasOne<Category>()
                .WithMany()
                .HasForeignKey(c => c.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            // FK: CreatedBy → AspNetUsers
            builder
                .HasOne<ApplicationUser>()
                .WithMany()
                .HasForeignKey(c => c.CreatedBy)
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
