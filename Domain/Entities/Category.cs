using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Category : BaseEntity
    {
        public Guid CompanyId { get; set; }
        public Guid? BranchId { get; set; } // NULL = global category

        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
