using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Identity
{
    public class RolePermission
    {
        public int Id { get; set; }
        public string RoleId { get; set; }
        public string Permission { get; set; }

        public ApplicationRole Role { get; set; }
    }
}
