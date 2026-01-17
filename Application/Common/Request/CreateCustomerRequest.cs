using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Request
{
    public class CreateCustomerRequest
    {
        public string Name { get; set; } = string.Empty;
        public Guid? BranchId { get; set; } // NULL = global category


        public string Phone { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public string CustomerType { get; set; } = string.Empty;
    }
}
