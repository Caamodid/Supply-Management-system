using Domain.Entities;
using Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            // Configure the CreatedBy property as a foreign key to ApplicationUser
            builder
                .HasOne<ApplicationUser>()
                .WithMany()
                .HasForeignKey(c => c.CreatedBy)  // This refers to the CreatedBy property in Company
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascading deletes
        }
    }
}
