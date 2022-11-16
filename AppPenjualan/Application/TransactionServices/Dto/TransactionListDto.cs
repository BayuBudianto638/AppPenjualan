using AppPenjualan.Database;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace AppPenjualan.Application.TransactionServices.Dto
{
    [AutoMap(typeof(Transactions))] // CreateMap<>();
    public class TransactionListDto
    {
        public string TransactionCode { get; set; }
        public Nullable<DateTime> TransactionDate { get; set; }
        public int Total { get; set; }
        public string Description { get; set; }
    }
}
