using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Response
{
    public class CustomerResponses
    {
        public Guid Id { get; set; } 

        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime CreatedAt { get; set; } 
        public DateTime? UpdatedAt { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Branch { get; set; } = string.Empty;
        public Guid BranchId { get; set; }

        public string Phone { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public string CustomerType { get; set; } = string.Empty;
    }
}
