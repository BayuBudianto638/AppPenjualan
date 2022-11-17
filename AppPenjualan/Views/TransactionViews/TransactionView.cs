using AppPenjualan.Application.ProductServices;
using AppPenjualan.Application.TransactionServices;
using AppPenjualan.Helpers;
using AppPenjualan.Views.ProductViews;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPenjualan.Views.TransactionViews
{
    public class TransactionView
    {
        private ITransactionAppService _transactionAppService;
        private CreateTransaction _createTransaction;
        private SearchTransaction _searchTransaction;
        public TransactionView(ITransactionAppService transactionAppService, 
            CreateTransaction createTransaction,
            SearchTransaction searchTransaction)
        {
            _transactionAppService = transactionAppService;
            _createTransaction = createTransaction;
            _searchTransaction = searchTransaction;
        }

        public void DisplayView()
        {
            Console.Clear();

            //Startup startup = new Startup();
            //var createTranView = startup.Provider.GetService<CreateTransaction>();
            //var searchView = startup.Provider.GetService<SearchTransaction>();

            // Get All Products Here
            bool showMenuPage = true;
            do
            {
                // fitur searching, order by, pagination
                Console.Clear();

                Console.Write("Enter Page : ");
                int page = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter Page Size : ");
                int pageSize = Convert.ToInt32(Console.ReadLine());

                var pageInfo = new PageInfo(page, pageSize);
                var transactionList = _transactionAppService.GetAllTransactions(pageInfo);

                decimal totalPage = transactionList.Total / pageSize;

                Console.WriteLine($"Display Page : {page} with total page : {(int)Math.Ceiling(totalPage)}");

                foreach (var transaction in transactionList.Data)
                {
                    Console.WriteLine($"{transaction.TransactionDate} - {transaction.TransactionDate} - " +
                        $"{transaction.Total} - {transaction.Description}");
                }

                Console.WriteLine();
                bool showMenu = true;
                while (showMenu)
                {
                    Console.WriteLine("Choose an option:");
                    Console.WriteLine("1) Create Transaction");
                    Console.WriteLine("2) Select Page");
                    Console.WriteLine("3) Search Transaction");
                    Console.WriteLine("4) Exit");
                    Console.Write("\r\nSelect an option: ");

                    switch (Console.ReadLine())
                    {
                        case "1":
                            _createTransaction.DisplayView();
                            showMenu = true;
                            break;
                        case "2":
                            showMenu = true;
                            break;
                        case "3":
                            _searchTransaction.DisplayView();
                            showMenu = true;
                            break;
                        case "4":
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
