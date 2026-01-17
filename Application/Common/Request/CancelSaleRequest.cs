using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Request
{
    public class CancelSaleRequest
    {
        public Guid SaleId { get; set; }
        public string Remark { get; set; } = string.Empty;
    }
}
