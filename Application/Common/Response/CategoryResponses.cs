using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Response
{
    public class CategoryResponses
    {
        public Guid Id { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; } 
        public string Company { get; set; }
        public Guid? BranchId { get; set; } // NULL = global category
        public string? BranchName{ get; set; } // NULL = global category


        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
