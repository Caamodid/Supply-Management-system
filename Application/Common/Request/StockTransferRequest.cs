using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Request
{
    public class StockTransferRequest
    {
        public Guid ProductId { get; set; }

        public Guid FromBranchId { get; set; }
        public Guid ToBranchId { get; set; }

        public decimal Quantity { get; set; }
    }

}
