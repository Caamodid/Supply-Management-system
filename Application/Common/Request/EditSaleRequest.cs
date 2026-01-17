using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Request
{
    public class EditSaleRequest
    {
        public Guid SaleId { get; set; }
        public decimal Discount { get; set; }
        public string? Remark { get; set; }
        public List<CreateSaleItemRequest> Items { get; set; } = new();
    }

}
