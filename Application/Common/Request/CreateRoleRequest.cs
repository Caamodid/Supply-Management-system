using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Request
{
    public class CreateRoleRequest
    {
        public string RoleName { get; set; }
        public string? Description { get; set; }
    }
}
