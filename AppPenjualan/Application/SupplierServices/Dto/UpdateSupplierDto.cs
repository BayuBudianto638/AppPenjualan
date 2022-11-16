using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPenjualan.Application.SupplierServices.Dto
{
    public class UpdateSupplierDto
    {
        public int SuppliersId { get; set; }
        public string SupplierName { get; set; }
        public string SupplierAddress { get; set; }
    }
}
