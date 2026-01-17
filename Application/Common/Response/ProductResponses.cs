using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Response
{
    public class ProductResponses
    {
        public Guid Id { get; set; }
        public string? CategoryTypeName { get; set; }
        public string? CategoryName { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }

        public string Unit { get; set; } = string.Empty;

        public decimal CostPrice { get; set; }
        public decimal SellPrice { get; set; }         // Retail price
        public decimal WholesalePrice { get; set; }    // Wholesale price


        public string? CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }

        public decimal Quantity { get; set; }
        public decimal MinStockLevel { get; set; }



    }
}
