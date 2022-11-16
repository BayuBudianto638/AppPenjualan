using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPenjualan.Database
{
    [Table("Transactions", Schema = "dbo")]
    public class Transactions
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Transaction Id")]
        public int TransactionsId { get; set; }
        [Required]
        [Column(TypeName = "Nvarchar(10)")]
        [Display(Name = "Transaction Code")]
        public string TransactionCode { get; set; }
        public Nullable<DateTime> TransactionDate { get; set; }
        public int Total { get; set; }
        public string Description { get; set; }
        public virtual ICollection<TransactionDetails> TransactionDetails { get; set; }
    }
}
