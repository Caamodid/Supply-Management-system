using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Request
{
    public class SalesListResponse
    {
        public Guid SaleId { get; set; }
        public string InvoiceNumber { get; set; } = string.Empty;

        public string CustomerName { get; set; } = string.Empty;
        public string BranchName { get; set; } = string.Empty;

        public decimal SubTotal { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal Balance { get; set; }

        public string PaymentStatus { get; set; } = string.Empty;
        public DateTime SaleDate { get; set; }
    }

}
