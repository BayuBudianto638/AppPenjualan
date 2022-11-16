using AppPenjualan.Application.ProductServices.Dto;
using AppPenjualan.Database;
using AppPenjualan.Helpers;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace AppPenjualan.Application.ProductServices
{
    public class ProductAppService : IProductAppService
    {
        private readonly PenjualanContext _penjualanContext;
        private IMapper _mapper;

        public ProductAppService(PenjualanContext penjualanContext, IMapper mapper)
        {
            _penjualanContext = penjualanContext;
            _mapper = mapper;
        }

        public PagedResult<ProductListDto> GetAllProducts(PageInfo pageinfo)
        {
            var pagedResult = new PagedResult<ProductListDto>
            {
                Data = (from product in _penjualanContext.Products
                        join supplier in _penjualanContext.Suppliers
                                 on product.SuppliersId equals supplier.SuppliersId
                        select new ProductListDto
                        {
                            ProductCode = product.ProductCode,
                            ProductName = product.ProductName,
                            ProductPrice = product.ProductPrice,
                            ProductQty = product.ProductQty,
                            SupplierName = supplier.SupplierName
                        })
                        .Skip(pageinfo.Skip)
                        .Take(pageinfo.PageSize)
                        .OrderBy(w => w.ProductCode),
                Total = _penjualanContext.Products.Count()
            };

            return pagedResult;

            #region Hide
            //var productListRepo = from product in _penjualanContext.Products
            //                      join supplier in _penjualanContext.Suppliers
            //                               on product.SuppliersId equals supplier.SuppliersId
            //                      select new ProductListDto
            //                      {
            //                          ProductCode = product.ProductCode,
            //                          ProductName = product.ProductName,
            //                          ProductPrice = product.ProductPrice,
            //                          ProductQty = product.ProductQty,
            //                          SupplierName = supplier.SupplierName
            //                      };
            //var productListDto = productListRepo.ToList();
            #endregion
        }

        public void Create(CreateProductDto model)
        {
            var product = _mapper.Map<Products>(model);
            _penjualanContext.Products.Add(product);
            _penjualanContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var product = _penjualanContext.Products.FirstOrDefault(w => w.ProductsId == id);

            if (product != null)
            {
                _penjualanContext.Products.Remove(product);
                _penjualanContext.SaveChanges();
            }
        }

        public void Update(UpdateProductDto model)
        {
            var product = _mapper.Map<Products>(model);
            _penjualanContext.Products.Update(product);
            _penjualanContext.SaveChanges();
        }

        public UpdateProductDto GetProductByCode(string code)
        {
            var product = _penjualanContext.Products.FirstOrDefault(w => w.ProductCode == code);
            var productDto = _mapper.Map<UpdateProductDto>(product);
            return productDto;
        }

        public PagedResult<ProductListDto> SearchProduct(string searchString, PageInfo pageInfo)
        {
            var products = from product in _penjualanContext.Products
                           select product;

            if (!String.IsNullOrEmpty(searchString))
            {
                products = products.Where(s => s.ProductName.Contains(searchString)
                                       || s.ProductCode.Contains(searchString));
            }

            var pagedResult = new PagedResult<ProductListDto>
            {
                Data = (from product in products
                        join supplier in _penjualanContext.Suppliers
                                 on product.SuppliersId equals supplier.SuppliersId
                        select new ProductListDto
                        {
                            ProductCode = product.ProductCode,
                            ProductName = product.ProductName,
                            ProductPrice = product.ProductPrice,
                            ProductQty = product.ProductQty,
                            SupplierName = supplier.SupplierName
                        })
                        .Skip(pageInfo.Skip)
                        .Take(pageInfo.PageSize)
                        .OrderBy(w => w.ProductCode),
                Total = _penjualanContext.Products.Count()
            };

            return pagedResult;

            ////var producListDto = _mapper.Map<List<ProductListDto>>(products);
            //return producListDto;
        }
    }
}
