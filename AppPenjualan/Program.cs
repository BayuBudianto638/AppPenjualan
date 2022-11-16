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
using AppPenjualan.ConfigProfile;
using AppPenjualan.Database;
using AppPenjualan.Views.ProductViews;
using AutoMapper;

class Program
{
    static void Main()
    {
        var config = new AutoMapper.MapperConfiguration(cfg=>
        {
            cfg.AddProfile(new ConfigurationProfile());
        });

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
                    var penjualanContext = new PenjualanContext();
                    IMapper mapper = new Mapper(config);
                    IProductAppService productAppService = new ProductAppService(penjualanContext, mapper);
                    var productView = new ProductView(productAppService);
                    productView.DisplayView();
                    showMenu = true;
                    break;
                case "2":
                    // View
                    showMenu = true;
                    break;
                case "3":
                    // View
                    showMenu = true;
                    break;
                case "4":
                    // View
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