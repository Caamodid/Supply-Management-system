using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Response
{
    public class CustomerCreditResponse
    {
        public Guid CustomerId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string InvoiceNo { get; set; } = string.Empty;
       

        // 💰 Financial
        public decimal TotalCredit { get; set; }
        public int UnpaidSalesCount { get; set; }

        // 📅 Dates
        public DateTime? LastSaleDate { get; set; }
        public DateTime? OldestUnpaidDate { get; set; }

        // 🚦 Simple risk indicator
        public string CreditStatus { get; set; } = string.Empty;
    }


}
