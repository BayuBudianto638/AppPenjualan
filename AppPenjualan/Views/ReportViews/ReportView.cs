using AppPenjualan.Application.TransactionServices;
using AppPenjualan.Database;
using AppPenjualan.Helpers;
using AppPenjualan.Views.TransactionViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPenjualan.Views.ReportViews
{
    public class ReportView
    {
        private PenjualanContext _penjualanContext;
        public ReportView(PenjualanContext penjualanContext)
        {
            _penjualanContext = penjualanContext;
        }

        public void DisplayView()
        {
            Console.Clear();
            var Data = (from a in _penjualanContext.Transactions
                        join b in _penjualanContext.TransactionDetails
                              on a.TransactionsId equals b.TransactionsId
                        join c in _penjualanContext.Products
                              on b.ProductsId equals c.ProductsId
                        join d in _penjualanContext.Suppliers
                              on c.SuppliersId equals d.SuppliersId
                        select new
                        {
                            Code = a.TransactionCode,
                            Date = a.TransactionDate,
                            Total = a.Total,
                            Product = c.ProductName,
                            Qty = b.Qty,
                            SubTotal = b.SubTotal
                        });

            foreach (var transaction in Data)
            {
                Console.WriteLine($"{transaction.Code} - {transaction.Date} - " +
                    $"{transaction.Total} - {transaction.Product} - " +
                   $"{transaction.Qty} - {transaction.SubTotal} - ");
            }

            Console.ReadKey();
        }
    }
}
