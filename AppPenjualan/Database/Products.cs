using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPenjualan.Database
{
    [Table("Products", Schema = "dbo")]
    public class Products
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Product Id")]
        public int ProductsId { get; set; }

        [Required] 
        [Column(TypeName = "Nvarchar(10)")] 
        [Display(Name = "Product Code")]
        public string ProductCode { get; set; }

        [Required]
        [Column(TypeName = "Nvarchar(100)")]
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }
        public int ProductPrice { get; set; }
        public int ProductQty { get; set; }
        public int SuppliersId { get; set; }

        public virtual ICollection<TransactionDetails> TransactionDetails { get; set; }
    }
}
