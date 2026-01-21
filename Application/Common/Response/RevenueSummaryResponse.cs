using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Response
{
    public class RevenueSummaryResponse
    {
        public DateTime Period { get; set; }
        public decimal TotalRevenue { get; set; }
        public DateTime LastCreatedAt { get; set; }
    }
}
