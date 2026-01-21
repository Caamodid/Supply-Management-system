using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Response
{
    public class ReportSection
    {
        public string Title { get; set; }
        public List<ReportLine> Lines { get; set; } = new();
        public decimal Total { get; set; }
    }

}
