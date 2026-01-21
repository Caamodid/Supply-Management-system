using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Response
{
    public class IncomeStatementReportResponse
    {
        public ReportPeriod Period { get; set; }

        public ReportSection Revenue { get; set; }

        public ReportSection CostOfGoodsSold { get; set; }

        public ReportSingleLine GrossProfit { get; set; }

        public ReportSection OperatingExpenses { get; set; }

        public ReportSingleLine NetProfit { get; set; }
    }

}
