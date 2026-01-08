using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Request
{
  public  class UpdateProductRequest
    {


        public Guid CompanyId { get; set; }        // FK → Company
        public Guid CategoryId { get; set; }       // FK → Category

        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }

        public string Unit { get; set; } = string.Empty;

        public decimal CostPrice { get; set; }
        public decimal SellPrice { get; set; }         // Retail price
        public decimal WholesalePrice { get; set; }    // Wholesale price
    }
}
