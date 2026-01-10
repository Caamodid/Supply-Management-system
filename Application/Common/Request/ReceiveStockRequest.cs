using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Request
{
    public class ReceiveStockRequest
    {
        public Guid ProductId { get; set; }
        public Guid BranchId { get; set; }
        public decimal Quantity { get; set; }
    }

}
