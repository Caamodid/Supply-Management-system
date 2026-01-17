using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class StockMovement : BaseEntity
    {
        public Guid ProductId { get; set; }
        public Guid BranchId { get; set; }
        // ✅ ADD THIS
        public string Reference { get; set; } = null!;
        public decimal? QuantityChange { get; set; } // + or -
        public string MovementType { get; set; }    // ADJUSTMENT

        public string? Reason { get; set; }

    }

}
