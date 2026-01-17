using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Request
{
    public class PayRemainingRequest
    {
        public Guid SaleId { get; set; }
        public decimal Amount { get; set; }
        public string? Remark { get; set; }
    }

}
