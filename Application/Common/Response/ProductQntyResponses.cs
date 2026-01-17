using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Response
{
    public class ProductQntyResponses
    {

        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal SellPrice { get; set; }
        public decimal Quantity { get; set; }
        public decimal WholesalePrice { get; set; }
        public string Unit { get; set; }

    }
}
