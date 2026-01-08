using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Request
{
    public class AssignUserRoleRequest
    {
        public string userId { get; set; }
        public string RoleName { get; set; }
    }
}
