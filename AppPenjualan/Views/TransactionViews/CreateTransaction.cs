using AppPenjualan.Application.ProductServices.Dto;
using AppPenjualan.Application.ProductServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppPenjualan.Application.TransactionServices;
using AppPenjualan.Application.TransactionDetailServices;
using AppPenjualan.Application.TransactionServices.Dto;
using AppPenjualan.Application.TransactionDetailServices.Dto;

namespace AppPenjualan.Views.TransactionViews
{
    public class CreateTransaction
    {
        private ITransactionAppService _transactionAppService;
        private ITransactionDetailAppService _transactionDetailAppService;
        private IProductAppService _productAppService;
        public CreateTransaction(ITransactionAppService transactionAppService,
            ITransactionDetailAppService transactionDetailAppService,
            IProductAppService productAppService)
        {
            _transactionAppService = transactionAppService;
            _transactionDetailAppService = transactionDetailAppService;
            _productAppService = productAppService;
        }

        public void DisplayView()
        {
            Console.Clear();
            Console.WriteLine("Create Transaction");
            Console.WriteLine("-------------------");

            var createTransaction = new CreateTransactionDto();
            createTransaction.TransactionDate = DateTime.Now;
            createTransaction.Total = 1000;
            createTransaction.Description = "Desc";
            var tranId = _transactionAppService.Create(createTransaction);
            var total = 0;
            bool repeat = true;
            while (repeat)
            {
                Console.Write("Masukkan Product : ");
                string code = Console.ReadLine();
                // search product
                var product = _productAppService.GetProductByCode(code);
                Console.Write("Masukkan Qty : ");
                int qty = Convert.ToInt32(Console.ReadLine());
                int subtotal = product.ProductPrice * qty;
                total = total + subtotal;

                var tranDetail = new CreateTransactionDetailDto();
                tranDetail.TransactionsId = tranId;
                tranDetail.ProductsId = product.ProductsId;
                tranDetail.Qty = qty;
                tranDetail.SubTotal = subtotal;
                // create transactiondetail
                _transactionDetailAppService.Create(tranDetail);
                _transactionAppService.UpdateTotal(tranId, total);

                Console.Write("Apakah ingin input lagi (Y/N)? ");
                string choice = Console.ReadLine();

                if (choice.ToUpper().Equals("Y"))
                    repeat = true;
                else
                    repeat = false;
            }


            Console.WriteLine("Record Saved!!");
            Console.ReadKey();
        }
    }
}
