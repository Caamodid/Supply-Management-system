using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Response
{
    public class ExpenseListResponse
    {
        public Guid ExpenseId { get; set; }
        public string CategoryName { get; set; } = null!;
        public string BranchName { get; set; } = null!;
        public decimal Amount { get; set; }
        public DateTime ExpenseDate { get; set; }
        public string? Remark { get; set; }
        public string? CreateBy { get; set; }
    }
}
