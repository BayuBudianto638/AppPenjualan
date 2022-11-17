using AppPenjualan.Application.ProductServices.Dto;
using AppPenjualan.Application.TransactionServices.Dto;
using AppPenjualan.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPenjualan.Application.TransactionServices
{
    public interface ITransactionAppService
    {
        int Create(CreateTransactionDto model);
        void UpdateTotal(int TransId, int Total);
        PagedResult<TransactionListDto> GetAllTransactions(PageInfo pageinfo);
        PagedResult<TransactionListDto> SearchTransaction(string searchString, PageInfo pageInfo);
    }
}
