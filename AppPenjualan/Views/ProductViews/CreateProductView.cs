using AppPenjualan.Application.ProductServices;
using AppPenjualan.Application.ProductServices.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPenjualan.Views.ProductViews
{
    public class CreateProductView
    {
        private IProductAppService _productAppService;
        public CreateProductView(IProductAppService productAppService)
        {
            _productAppService = productAppService;
        }

        public void DisplayView()
        {
            Console.Clear();
            Console.WriteLine("Create Product");
            Console.WriteLine("--------------");

            Console.Write("Product Code: ");
            string code = Console.ReadLine();
            Console.Write("Product Name : ");
            string name = Console.ReadLine();
            Console.Write("Product Price : ");
            int price = Convert.ToInt32(Console.ReadLine());
            Console.Write("Product Qty : ");
            int qty = Convert.ToInt32(Console.ReadLine());
            Console.Write("Supplier Id : ");
            int supplierId = Convert.ToInt32(Console.ReadLine());

            var createProduct = new CreateProductDto()
            {
                ProductCode = code,
                ProductName = name,
                ProductPrice = price,
                ProductQty = qty,
                SuppliersId = supplierId
            };

            _productAppService.Create(createProduct);
            Console.WriteLine("Record Saved!!");
            Console.ReadKey();
        }
    }
}
