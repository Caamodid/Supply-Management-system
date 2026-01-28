using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Response
{
    public class CustomerTransactionPaperResponse
    {
        // ===== HEADER (MAIN INFO) =====
        public Guid CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public decimal Balance { get; set; }

        // ===== DETAIL (TRANSACTIONS) =====
        public List<CustomerTransactionDetailItem> Transactions { get; set; }
    }

    public class CustomerTransactionDetailItem
    {
        public Guid TransactionId { get; set; }
        public DateTime TransactionDate { get; set; }
        public string TransactionType { get; set; }
        public decimal Amount { get; set; }
        public string? CreatedBy { get; set; }
        public string? Remark { get; set; }
    }
}
