using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Response
{
    public class StockListResponse
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string Unit { get; set; } = string.Empty;

        public Guid BranchId { get; set; }
        public string BranchName { get; set; } = string.Empty;

        public decimal Quantity { get; set; }
        public decimal MinStockLevel { get; set; }

        public bool IsLowStock => Quantity <= MinStockLevel;
    }

}
