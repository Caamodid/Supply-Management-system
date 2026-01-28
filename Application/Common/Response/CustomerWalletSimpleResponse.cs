using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Response
{
    public class CustomerWalletSimpleResponse
    {
        public Guid CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public decimal Balance { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? CreatedBy { get; set; }

    }
}
