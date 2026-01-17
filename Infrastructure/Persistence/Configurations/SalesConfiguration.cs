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
    public class SalesConfiguration : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            // FK: Sales → Company
            builder
                .HasOne<Customer>()
                .WithMany()
                .HasForeignKey(b => b.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);


            // FK: Branch → Company
            builder
                .HasOne<Branch>()
                .WithMany()
                .HasForeignKey(b => b.BranchId)
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
