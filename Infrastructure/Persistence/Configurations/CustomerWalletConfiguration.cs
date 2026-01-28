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
    public class CustomerWalletConfiguration : IEntityTypeConfiguration<CustomerWallet>
    {
        public void Configure(EntityTypeBuilder<CustomerWallet> builder)
        {

            // FK: CategoryType → Category
            builder
                .HasOne<Customer>()
                .WithMany()
                .HasForeignKey(c => c.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);
            // Configure the CreatedBy property as a foreign key to ApplicationUser
            builder
                .HasOne<ApplicationUser>()
                .WithMany()
                .HasForeignKey(c => c.CreatedBy)  // This refers to the CreatedBy property in Company
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascading deletes
        }
    }
}
