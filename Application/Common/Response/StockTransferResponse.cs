using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Response
{
    public class StockTransferResponse
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; } = null!;

        public Guid FromBranchId { get; set; }
        public string FromBranchName { get; set; } = null!;

        public Guid ToBranchId { get; set; }
        public string ToBranchName { get; set; } = null!;

        public decimal Quantity { get; set; }

        public DateTime TransferDate { get; set; }
        public string TransferredBy { get; set; } = null!;
    }

}
