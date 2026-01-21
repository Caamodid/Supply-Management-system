using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Expense : BaseEntity
    {

        public Guid ExpenseCategoryId { get; set; }
        public Guid BranchId { get; set; }

        public decimal Amount { get; set; }

        public DateTime ExpenseDate { get; set; }
        public string? Remark { get; set; }


    }
}
