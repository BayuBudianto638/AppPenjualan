using AppPenjualan.Application.ProductServices.Dto;
using AppPenjualan.Application.TransactionServices.Dto;
using AppPenjualan.Database;
using AppPenjualan.Helpers;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPenjualan.Application.TransactionServices
{
    internal class TransactionAppService : ITransactionAppService
    {
        private readonly PenjualanContext _penjualanContext;
        private IMapper _mapper;

        public TransactionAppService(PenjualanContext penjualanContext, IMapper mapper)
        {
            _penjualanContext = penjualanContext;
            _mapper = mapper;
        }

        public int Create(CreateTransactionDto model)
        {
            var transaction = _mapper.Map<Transactions>(model);
            transaction.TransactionCode = AutoGenerate();

            _penjualanContext.Transactions.Add(transaction);
            _penjualanContext.SaveChanges();
            _penjualanContext.Entry(transaction).GetDatabaseValues();
            int id = transaction.TransactionsId;
            return id;
        }

        public PagedResult<TransactionListDto> GetAllTransactions(PageInfo pageInfo)
        {
            var pagedResult = new PagedResult<TransactionListDto>
            {
                Data = (from transaction in _penjualanContext.Transactions
                        select new TransactionListDto
                        {
                            TransactionCode = transaction.TransactionCode,
                            TransactionDate = transaction.TransactionDate,
                            Total = transaction.Total,
                            Description = transaction.Description
                        })
                        .Skip(pageInfo.Skip)
                        .Take(pageInfo.PageSize)
                        .OrderBy(w => w.TransactionCode),
                Total = _penjualanContext.Products.Count()
            };

            return pagedResult;

            //var transactionList = _penjualanContext.Transactions.ToList();
            //var transactionListDto = _mapper.Map<List<TransactionListDto>>(transactionList);

            //return transactionListDto;
        }

        public PagedResult<TransactionListDto> SearchTransaction(string searchString, PageInfo pageInfo)
        {
            var transactions = from transaction in _penjualanContext.Transactions
                           select transaction;

            if (!String.IsNullOrEmpty(searchString))
            {
                transactions = transactions.Where(s => s.TransactionCode.Contains(searchString));
            }

            var pagedResult = new PagedResult<TransactionListDto>
            {
                Data = (from transaction in transactions
                        select new TransactionListDto
                        {
                            TransactionCode = transaction.TransactionCode,
                            TransactionDate = transaction.TransactionDate,
                            Total = transaction.Total,
                            Description = transaction.Description
                        })
                        .Skip(pageInfo.Skip)
                        .Take(pageInfo.PageSize)
                        .OrderBy(w => w.TransactionCode),
                Total = _penjualanContext.Products.Count()
            };

            return pagedResult;
        }

        public void UpdateTotal(int TransId, int Total)
        {
            var transaction = _penjualanContext
                .Transactions.FirstOrDefault(t => t.TransactionsId == TransId);

            transaction.Total = Total;

            _penjualanContext.Transactions.Update(transaction);
            _penjualanContext.SaveChanges();
        }

        private string AutoGenerate()
        {
            // TR-ddMM001
            int num = _penjualanContext.Transactions.Where(w=>w.TransactionDate == DateTime.Now).Count();
            string runningNo = Convert.ToString(num + 1).PadLeft(3, '0');//001
            string code = "TR-" + DateTime.Now.ToString("ddMM") + runningNo;
            return code;
        }
    }
}
