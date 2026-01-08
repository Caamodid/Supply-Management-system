using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Branch : BaseEntity
    {
        public Guid CompanyId { get; set; }      
        public string BranchName { get; set; } = string.Empty;
        public string? Address { get; set; }
        public string? Phone { get; set; }
    }
}
