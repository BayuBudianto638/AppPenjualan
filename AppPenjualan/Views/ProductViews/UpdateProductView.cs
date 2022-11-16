using AppPenjualan.Application.ProductServices;
using AppPenjualan.Application.ProductServices.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPenjualan.Views.ProductViews
{
    public class UpdateProductView
    {
        private IProductAppService _productAppService;
        public UpdateProductView(IProductAppService productAppService)
        {
            _productAppService = productAppService;
        }

        public void DisplayView()
        {
            Console.Clear();
            Console.WriteLine("Update Product");
            Console.Write("Cari Product Code : ");
            string codeSearch = Console.ReadLine();

            var product = _productAppService.GetProductByCode(codeSearch);
            if (product != null)
            {
                Console.WriteLine($"Product Code : {product.ProductCode}");
                Console.WriteLine($"Product Name : {product.ProductName}");
                Console.WriteLine($"Product Price : {product.ProductPrice}");
                Console.WriteLine($"Product Qty : {product.ProductQty}");
                Console.WriteLine($"Supplier : {product.SuppliersId}");

                Console.WriteLine("------------------------------");
                Console.Write("Product Code : ");
                string code = Console.ReadLine();
                Console.WriteLine("Product Name : ");
                string name = Console.ReadLine();
                Console.WriteLine("Product Price : ");
                int price = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Product Qty : ");
                int qty = Convert.ToInt32(Console.ReadLine());
                Console.Write("Supplier : ");
                int supplierId = Convert.ToInt32(Console.ReadLine());

                var productDto = new UpdateProductDto();
                productDto.ProductCode = code;
                productDto.ProductName = name;
                productDto.ProductPrice = price;
                productDto.ProductQty = qty;
                productDto.SuppliersId = supplierId;

                _productAppService.Update(productDto);
            }
        }
    }
}
