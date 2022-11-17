using AppPenjualan.Application.ProductServices;
using AppPenjualan.Application.TransactionServices;
using AppPenjualan.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPenjualan.Views.TransactionViews
{
    public class SearchTransaction
    {
        private ITransactionAppService _transactionAppService;
        public SearchTransaction(ITransactionAppService transactionAppService)
        {
            _transactionAppService = transactionAppService;
        }

        public void DisplayView()
        {
            Console.Clear();
            Console.WriteLine("Search Transaction");
            Console.WriteLine("--------------");

            Console.Write("Search Transaction Code: ");
            string searchString = Console.ReadLine();

            Console.Write("Enter Page : ");
            int page = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Page Size : ");
            int pageSize = Convert.ToInt32(Console.ReadLine());

            var pageInfo = new PageInfo(page, pageSize);
            var transactionList = _transactionAppService.SearchTransaction(searchString, pageInfo);

            var totalPage = transactionList.Total / pageSize;

            Console.WriteLine($"Display Page : {page} with total page : {Math.Abs(totalPage)}");

            foreach (var transaction in transactionList.Data)
            {
                Console.WriteLine($"{transaction.TransactionCode} - {transaction.TransactionDate} - " +
                        $"{transaction.Total} - {transaction.Description}");
            }

            Console.ReadKey();
        }
    }
}
