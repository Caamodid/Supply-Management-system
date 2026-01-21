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
    public class ExpensesConfiguration : IEntityTypeConfiguration<Expense>
    {

        public void Configure(EntityTypeBuilder<Expense> builder)
        {
            // FK: Branch → Company
            builder
                .HasOne<ExpenseCategory>()
                .WithMany()
                .HasForeignKey(b => b.ExpenseCategoryId)
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
