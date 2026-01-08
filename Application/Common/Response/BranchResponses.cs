using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Response
{
    public class BranchResponses
    {
        public Guid Id { get; set; }

        public bool IsActive { get; set; } = true;
        public string? CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }

        public string CompnayName { get; set; }
        public string BranchName { get; set; } = string.Empty;
        public string? Address { get; set; }
        public string? Phone { get; set; }
    }
}
