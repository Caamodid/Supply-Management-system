using Application.Common.Wrapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Request
{
    public class UpdateRoleCommand : IRequest<ResponseWrapper<bool>>
    {
        public string RoleId { get; set; } = default!;
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
    }
}
