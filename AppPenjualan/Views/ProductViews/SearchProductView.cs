using AppPenjualan.Application.ProductServices.Dto;
using AppPenjualan.Application.ProductServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppPenjualan.Helpers;

namespace AppPenjualan.Views.ProductViews
{
    public class SearchProductView
    {
        private IProductAppService _productAppService;
        public SearchProductView(IProductAppService productAppService)
        {
            _productAppService = productAppService;
        }

        public void DisplayView()
        {
            Console.Clear();
            Console.WriteLine("Search Product");
            Console.WriteLine("--------------");

            Console.Write("Search Product By Name or Code: ");
            string searchString = Console.ReadLine();

            Console.Write("Enter Page : ");
            int page = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Page Size : ");
            int pageSize = Convert.ToInt32(Console.ReadLine());

            var pageInfo = new PageInfo(page, pageSize);
            var productList = _productAppService.SearchProduct(searchString, pageInfo);

            var totalPage = productList.Total / pageSize;

            Console.WriteLine($"Display Page : {page} with total page : {Math.Abs(totalPage)}");

            foreach (var product in productList.Data)
            {
                Console.WriteLine($"{product.ProductCode} - {product.ProductName} - " +
                    $"{product.ProductPrice} - {product.ProductQty} - {product.SupplierName}");
            }

            Console.ReadKey();
        }
    }
}
