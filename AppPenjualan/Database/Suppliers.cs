using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPenjualan.Database
{
    [Table("Suppliers", Schema = "dbo")]
    public class Suppliers
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Supplier Id")]
        public int SuppliersId { get; set; }
        [Required]
        [Column(TypeName = "Nvarchar(100)")]
        [Display(Name = "Supplier Name")]
        public string SupplierName { get; set; }
        public string SupplierAddress { get; set; }

        public virtual ICollection<Products> Products { get; set; }
    }
}
