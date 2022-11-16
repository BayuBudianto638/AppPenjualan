using AppPenjualan.Application.TransactionDetailServices.Dto;
using AppPenjualan.Database;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPenjualan.Application.TransactionDetailServices
{
    public class TransactionDetailAppService : ITransactionDetailAppService
    {
        private readonly PenjualanContext _penjualanContext;
        private IMapper _mapper;

        public TransactionDetailAppService(PenjualanContext penjualanContext, IMapper mapper)
        {
            _penjualanContext = penjualanContext;
            _mapper = mapper;
        }

        public void Create(CreateTransactionDetailDto model)
        {
            var transactionDetail = _mapper.Map<TransactionDetails>(model);
            _penjualanContext.TransactionDetails.Add(transactionDetail);
            _penjualanContext.SaveChanges();
        }

        public void Delete(int Id)
        {
            var transactionDetail = _penjualanContext
                .TransactionDetails.FirstOrDefault(w => w.TransactionDetailId == Id);

            if (transactionDetail != null)
            {
                _penjualanContext.TransactionDetails.Remove(transactionDetail);
                _penjualanContext.SaveChanges();
            }
        }

        public List<TransactionDetailListDto> GetTransactionDetail(int TransactionId)
        {
            var transactionDetailList = _penjualanContext.TransactionDetails.ToList();
            var transactionDetailListDto = _mapper.Map<List<TransactionDetailListDto>>(transactionDetailList);
            return transactionDetailListDto;
        }

        public void Update(UpdateTransactionDetailDto model)
        {
            var transactionDetail = _mapper.Map<TransactionDetails>(model);
            _penjualanContext.TransactionDetails.Update(transactionDetail);
            _penjualanContext.SaveChanges();
        }
    }
}
