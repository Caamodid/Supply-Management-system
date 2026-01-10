using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Request
{
    public class OpenProductConversionRequest
    {
        public Guid FromProductId { get; set; }   // Cement sack
        public Guid ToProductId { get; set; }     // Cement loose
        public Guid BranchId { get; set; }

        public decimal OpenQuantity { get; set; } // e.g. 1 sack
        public decimal ConversionValue { get; set; } // e.g. 50 kg
    }

}
