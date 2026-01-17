using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Sale : BaseEntity
    {

        public string InvoiceNumber { get; set; } = string.Empty;
        public Guid ?CustomerId { get; set; }
        public Guid BranchId { get; set; }
        public bool IsWalkIn { get; set; }
        public decimal SubTotal { get; set; }

        public decimal Discount { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal Balance { get; set; }
        public string PaymentStatus { get; set; } = string.Empty;

        public DateTime SaleDate { get; set; } = DateTime.UtcNow;
        public bool IsDeleted { get; set; } = false;


        public string? Remark { get; set; }
    }
}
