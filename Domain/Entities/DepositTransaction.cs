using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class DepositTransaction : BaseEntity
    {
        [Required]
        public Guid CustomerId { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }
        // + = add money, - = use money

        [Required]
        [MaxLength(20)]
        public string TransactionType { get; set; }
        // Deposit | Purchase | Refund | OwnerUse | OwnerReturn
        public string? Remark { get; set; } = string.Empty;

    }
}
