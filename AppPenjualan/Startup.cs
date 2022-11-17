using AppPenjualan.Application.ProductServices;
using AppPenjualan.Application.SupplierServices;
using AppPenjualan.Application.TransactionDetailServices;
using AppPenjualan.Application.TransactionServices;
using AppPenjualan.ConfigProfile;
using AppPenjualan.Database;
using AppPenjualan.Views.ProductViews;
using AppPenjualan.Views.ReportViews;
using AppPenjualan.Views.TransactionViews;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPenjualan
{
    public class Startup
    {
        IConfigurationRoot Configuration { get; }
        public IServiceProvider Provider { get; }
        public Startup()
        {
            var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: false);
            Configuration = builder.Build();
            Provider = ConfigureServices();
        }

        private IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ConfigurationProfile());
            });

            var mapper = config.CreateMapper();

            services.AddLogging();
            services.AddSingleton<IConfigurationRoot>(Configuration);
            // Create Services
            services.AddSingleton(mapper);
            services.AddSingleton<IProductAppService, ProductAppService>();
            services.AddSingleton<ISupplierAppService, SupplierAppService>();
            services.AddSingleton<ITransactionAppService, TransactionAppService>();
            services.AddSingleton<ITransactionDetailAppService, TransactionDetailAppService>();

            // DBContext
            services.AddDbContext<PenjualanContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DBConnection"), builder =>
                                        builder.MigrationsAssembly("migration.presentence"));
            }, ServiceLifetime.Singleton);

            services.AddSingleton<ProductView>();
            services.AddSingleton<CreateTransaction>();
            services.AddSingleton<SearchTransaction>();
            services.AddSingleton<TransactionView>();
            services.AddSingleton<ReportView>();
           
            return services.BuildServiceProvider();
        }
    }
}
