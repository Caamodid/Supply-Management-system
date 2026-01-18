using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Response
{
    public class InvoiceListResponse
    {
        public Guid InvoiceId { get; set; }          // For View / Print action
        public string InvoiceNumber { get; set; }    // INV-20260115-001

        public string CustomerName { get; set; }     // Display in table

        public decimal TotalAmount { get; set; }     // Invoice total
        public decimal Balance { get; set; }         // Remaining balance
        public decimal Paid { get; set; }         // Remaining balance
        public decimal discount { get; set; }         // Remaining balance

        public string Status { get; set; }           // OPEN / PARTIAL / CLOSED

        public DateTime CreatedAt { get; set; }      // Invoice date
    }
}
