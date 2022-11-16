using AppPenjualan.Application.ProductServices.Dto;
using AppPenjualan.Application.SupplierServices.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPenjualan.Application.SupplierServices
{
    public interface ISupplierAppService
    {
        void Create(CreateSupplierDto model);
        void Update(UpdateSupplierDto model);
        void Delete(int id);
        List<SupplierListDto> GetAllProducts();
    }
}
