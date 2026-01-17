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
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {

        public void Configure(EntityTypeBuilder<Customer> builder)
        {



            // FK: Customer → Branch (required)
            builder
                .HasOne<Branch>()
                .WithMany()
                .HasForeignKey(c => c.BranchId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configure the CreatedBy property as a foreign key to ApplicationUser
            builder
                .HasOne<ApplicationUser>()
                .WithMany()
                .HasForeignKey(c => c.CreatedBy)  // This refers to the CreatedBy property in Customer
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascading deletes
        }
    }
}
