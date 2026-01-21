using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Response
{
    public class ExpenseTypeResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty!;
        public string? Description { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
        public string? CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
