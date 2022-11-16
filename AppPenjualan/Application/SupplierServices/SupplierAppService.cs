using AppPenjualan.Application.SupplierServices.Dto;
using AppPenjualan.Database;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPenjualan.Application.SupplierServices
{
    public class SupplierAppService : ISupplierAppService
    {
        private readonly PenjualanContext _penjualanContext;
        private IMapper _mapper;
        public SupplierAppService(PenjualanContext penjualanContext, IMapper mapper)
        {
            _penjualanContext = penjualanContext;
            _mapper = mapper;
        }

        public void Create(CreateSupplierDto model)
        {
            var supplier = _mapper.Map<Suppliers>(model);
            _penjualanContext.Suppliers.Add(supplier);
            _penjualanContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var supplier = _penjualanContext.Suppliers.FirstOrDefault(w => w.SuppliersId == id);
            if (supplier!=null)
            {
                _penjualanContext.Suppliers.Remove(supplier);
                _penjualanContext.SaveChanges();
            }
        }

        public List<SupplierListDto> GetAllProducts()
        {
            var supplierList = _penjualanContext.Suppliers.ToList();

            var supplierListDto = _mapper.Map<List<SupplierListDto>>(supplierList);

            return supplierListDto;
        }

        public void Update(UpdateSupplierDto model)
        {
            var supplier = _mapper.Map<Suppliers>(model);
            _penjualanContext.Suppliers.Update(supplier);
            _penjualanContext.SaveChanges();
        }
    }
}
