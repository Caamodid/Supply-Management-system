using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Request
{
  public  class UpdateBranchRequest
    {
        public Guid CompanyId { get; set; }
        public string BranchName { get; set; } = string.Empty;
        public string? Address { get; set; }
        public string? Phone { get; set; }
    }
}
