using AppPenjualan.Application.TransactionDetailServices.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPenjualan.Application.TransactionDetailServices
{
    public interface ITransactionDetailAppService
    {
        void Create(CreateTransactionDetailDto model);
        void Update(UpdateTransactionDetailDto model);
        void Delete(int Id);
        List<TransactionDetailListDto> GetTransactionDetail(int TransactionId);
    }
}
