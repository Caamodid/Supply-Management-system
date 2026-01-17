using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Response
{
    public class SaleDetailResponse
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
        public string? Remark { get; set; }
        public string? CreatedBy { get; set; }


        public string PaymentStatus { get; set; } = string.Empty;
        public DateTime SaleDate { get; set; }

        public List<SaleItemDetailResponse> Items { get; set; } = new();
    }

    public class SaleItemDetailResponse
    {
        public string ProductName { get; set; } = string.Empty;
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal LineTotal { get; set; }
    }

}
