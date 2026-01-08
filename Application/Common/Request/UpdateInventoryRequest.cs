using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Request
{
   public class UpdateInventoryRequest
    {

        public Guid ProductId { get; set; }      // FK → Product
        public Guid BranchId { get; set; }       // FK → Branch

        public decimal Quantity { get; set; }
        public decimal MinStockLevel { get; set; }
    }
}
