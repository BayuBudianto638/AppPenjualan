using AppPenjualan.Application.TransactionServices.Dto;
using AppPenjualan.Database;
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
            _penjualanContext.Transactions.Add(transaction);
            _penjualanContext.SaveChanges();

            int id = model.TransactionsId;
            return id;
        }

        public List<TransactionListDto> GetAllTransactions()
        {
            var transactionList = _penjualanContext.Transactions.ToList();
            var transactionListDto = _mapper.Map<List<TransactionListDto>>(transactionList);

            return transactionListDto;
        }
    }
}
