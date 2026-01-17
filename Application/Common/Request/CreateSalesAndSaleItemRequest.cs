using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Request
{
    public class CreateSalesAndSaleItemRequest
    {
        public CreateSalesRequest Sale { get; set; } = default!;
        public List<CreateSaleItemRequest> Items { get; set; } = new();
    }
}
