using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Request
{
    public class CreateSalesRequest
    {

        public Guid? CustomerId { get; set; }
        public Guid BranchId { get; set; }
        public decimal SubTotal { get; set; }
        public bool IsWalkIn { get; set; }


        public decimal Discount { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal Balance { get; set; }
        public string PaymentStatus { get; set; } = string.Empty;
        public string? Remark { get; set; }



    }
}
