//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Domain.Entities
//{
//    public class GoodsReceipt : BaseEntity
//    {
//        public Guid PurchaseOrderId { get; set; }
//        public Guid BranchId { get; set; }

//        public string ReceiptNumber { get; set; } = string.Empty;

//        public DateTime ReceiptDate { get; set; } = DateTime.UtcNow;

//        // DRAFT / POSTED / CANCELLED
//        public string Status { get; set; } = "POSTED";

//        public string? Remark { get; set; }
//    }
//}
