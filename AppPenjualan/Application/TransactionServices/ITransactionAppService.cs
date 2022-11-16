using AppPenjualan.Application.TransactionServices.Dto;
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
        List<TransactionListDto> GetAllTransactions();
    }
}
