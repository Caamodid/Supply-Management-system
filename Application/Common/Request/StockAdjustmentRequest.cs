using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Request
{
    public class StockAdjustmentRequest
    {
        public Guid ProductId { get; set; }
        public Guid BranchId { get; set; }

        public decimal NewQuantity { get; set; }   // Final correct quantity
        public string Reason { get; set; } = string.Empty;
    }

}
