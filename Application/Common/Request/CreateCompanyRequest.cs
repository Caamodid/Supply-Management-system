using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;


namespace Application.Common.Request
{
    public class CreateCompanyRequest
    {

        public string Name { get; set; } = string.Empty;
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public IFormFile? LogoFile { get; set; } // Add IFormFile to handle file upload    }
    }
}
