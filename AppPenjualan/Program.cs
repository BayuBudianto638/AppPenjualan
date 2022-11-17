// Application Services
// Databases
// Views
/*
 *  IMapper mapper = config.CreateMapper();
        var penjualanContext = new PenjualanContext();
        ProductAppService pa = new ProductAppService(penjualanContext, mapper);
        pa.GetAllProducts();
 */

//Product ---> Berisi produk2 yg ada di toko
//Supplier ---> Berisi supplier yang membawa produk2
//Transaction ---> TranDate dan TranCode
//TransactionDetail ---> Product Yang dibeli
using AppPenjualan.Application.ProductServices;
using AppPenjualan.Application.SupplierServices;
using AppPenjualan.ConfigProfile;
using AppPenjualan.Database;
using AppPenjualan.Views.ProductViews;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using AppPenjualan;
using AppPenjualan.Views.TransactionViews;
using AppPenjualan.Views.ReportViews;

class Program
{
    static void Main()
    {
        #region Hide
        /*
         *Dependency Injection merupakan sebuah teknik untuk mengatur cara
         *bagaimana suatu objek dibentuk ketika terdapat objek lain yang membutuhkan. 
         */

        //var serviceProvider = new ServiceCollection()
        //.AddLogging()
        //// Singleton,Transient dan Scoped
        //// Singleton = Object di create cuma 1x, setiap request akan memakai object yg sama
        //// Transient = Object akan di create setiap kali request untuk dicreate
        //// Scoped = object dicreate 1x tapi berbeda dalam setiap request

        //.AddSingleton<IProductAppService, ProductAppService>()
        //.AddSingleton<ProductView>(x =>
        //             new ProductView(x.GetService<IProductAppService>()))
        //.BuildServiceProvider();

        //var productAppService = serviceProvider.GetService<IProductAppService>();
        //var productView = serviceProvider.GetService<ProductView>();

        //IServiceCollection services = new ServiceCollection();
        //Startup startup = new Startup();
        //startup.ConfigureServices(services);
        //IServiceProvider serviceProvider = services.BuildServiceProvider();
        #endregion

        Startup startup = new Startup();
        var productView = startup.Provider.GetService<ProductView>();
        var tranView = startup.Provider.GetService<TransactionView>();
        var reportView = startup.Provider.GetService<ReportView>();

        bool showMenu = true;
        while (showMenu)
        {
            Console.Clear();
            Console.WriteLine("Point Of Sales EnigmaCamp");
            Console.WriteLine("--------------------------");
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1) Products");
            Console.WriteLine("2) Suppliers");
            Console.WriteLine("3) Transaction");
            Console.WriteLine("4) Reports");
            Console.WriteLine("5) Exit");
            Console.Write("\r\nSelect an option: ");

            switch (Console.ReadLine())
            {
                case "1":
                    // View
                    //var penjualanContext = new PenjualanContext();
                    //IMapper mapper = new Mapper(config);
                    //IProductAppService productAppService = new ProductAppService(penjualanContext, mapper);
                    //var productView = new ProductView(productAppService);
                    productView.DisplayView();
                    showMenu = true;
                    break;
                case "2":
                    // View
                    showMenu = true;
                    break;
                case "3":
                    // View
                    tranView.DisplayView();
                    showMenu = true;
                    break;
                case "4":
                    // View
                    reportView.DisplayView();
                    showMenu = true;
                    break;
                case "5":
                    showMenu = false;
                    break;
                default:
                    showMenu = true;
                    break;
            }
        }
    }
}