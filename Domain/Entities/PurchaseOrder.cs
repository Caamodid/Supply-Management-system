//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Domain.Entities
//{
//    public class PurchaseOrder : BaseEntity
//    {
//        public Guid SupplierId { get; set; }
//        public Guid CompanyId { get; set; }
//        public Guid BranchId { get; set; }

//        public string OrderNumber { get; set; } = string.Empty;

//        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
//        public DateTime? ExpectedDate { get; set; }

//        public decimal SubTotal { get; set; }
//        public decimal Discount { get; set; }
//        public decimal TotalAmount { get; set; }

//        // DRAFT / APPROVED / PARTIAL_RECEIVED / RECEIVED / CANCELLED
//        public string Status { get; set; } = "DRAFT";

//        public string? Remark { get; set; }
//    }
//}
