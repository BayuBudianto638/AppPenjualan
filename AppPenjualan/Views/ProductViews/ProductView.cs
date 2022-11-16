using AppPenjualan.Application.ProductServices;
using AppPenjualan.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPenjualan.Views.ProductViews
{
    public class ProductView
    {
        private IProductAppService _productAppService;
        public ProductView(IProductAppService productAppService)
        {
            _productAppService = productAppService;
        }

        public void DisplayView()
        {
            Console.Clear();
            // Get All Products Here
            bool showMenuPage = true;
            int RecordsPerPage = 4;
            int PageNumber = 0;
            do
            {
                // fitur searching, order by, pagination
                Console.Clear();

                Console.Write("Enter Page : ");
                int page = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter Page Size : ");
                int pageSize = Convert.ToInt32(Console.ReadLine());

                var pageInfo = new PageInfo(page, pageSize);
                var productList = _productAppService.GetAllProducts(pageInfo);

                var totalPage = productList.Total / pageSize;

                Console.WriteLine($"Display Page : {page} with total page : {Math.Abs(totalPage)}");

                foreach (var product in productList.Data)
                {
                    Console.WriteLine($"{product.ProductCode} - {product.ProductName} - " +
                        $"{product.ProductPrice} - {product.ProductQty} - {product.SupplierName}");
                }

                #region Hide
                //if (int.TryParse(Console.ReadLine(), out PageNumber))
                //{
                //    if (PageNumber > 0 && PageNumber < 5)
                //    {
                //        var productList = _productAppService.GetAllProducts()
                //                            .Skip((PageNumber - 1) * RecordsPerPage)
                //                            .Take(RecordsPerPage)
                //                            .ToList();

                //        foreach (var product in productList)
                //        {
                //            Console.WriteLine($"{product.ProductCode} - {product.ProductName} - " +
                //                $"{product.ProductPrice} - {product.ProductQty} - {product.SupplierName}");
                //        }
                //    }
                //}
                #endregion

                Console.WriteLine();
                bool showMenu = true;
                while (showMenu)
                {
                    Console.WriteLine("Choose an option:");
                    Console.WriteLine("1) Create Product");
                    Console.WriteLine("2) Update Product");
                    Console.WriteLine("3) Delete Product");
                    Console.WriteLine("4) Select Page");
                    Console.WriteLine("5) Search Product");
                    Console.WriteLine("6) Exit");
                    Console.Write("\r\nSelect an option: ");

                    switch (Console.ReadLine())
                    {
                        case "1":
                            showMenu = true;
                            break;
                        case "2":
                            showMenu = true;
                            break;
                        case "3":
                            showMenu = true;
                            break;
                        case "4":
                            showMenu = false;
                            break;
                        case "5":
                            showMenu = true;
                            break;
                        case "6":
                            showMenuPage = false;
                            showMenu = false;
                            break;
                        default:
                            showMenu = true;
                            break;
                    }
                }
            } while (showMenuPage);
        }
    }
}
