using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Response
{
    public class StockMovementResponse
    {
        public Guid StockMovementId { get; set; }

        public Guid ProductId { get; set; }
        public string ProductName { get; set; }

        public Guid BranchId { get; set; }
        public string BranchName { get; set; }

        public decimal? QuantityChange { get; set; }
        public string MovementType { get; set; }
        public string Reason { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}
