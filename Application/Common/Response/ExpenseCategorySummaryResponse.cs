using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Response
{
    public class ExpenseCategorySummaryResponse
    {
        public string CategoryName { get; set; } = null!;
        public decimal TotalAmount { get; set; }
        public DateTime LastExpenseAt { get; set; }
    }
}
