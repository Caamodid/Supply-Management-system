using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Response
{
    public class ProductWithCategoryAndWithCategoryTypeAndBranchResponses
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; } = default!;
        public decimal Price { get; set; } 
        public decimal WholePrice { get; set; } 
        public string CategoryName { get; set; } = default!;
        public string CategoryTypeName { get; set; } = default!;
        public decimal Quantity { get; set; } 
        public string BranchName { get; set; } = default!;
        public Guid BranchId { get; set; } 
    }
}
