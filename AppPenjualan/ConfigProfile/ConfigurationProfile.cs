using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppPenjualan.Application.ProductServices.Dto;
using AppPenjualan.Application.SupplierServices.Dto;
using AppPenjualan.Application.TransactionDetailServices.Dto;
using AppPenjualan.Application.TransactionServices.Dto;
using AppPenjualan.Database;
using AutoMapper;

namespace AppPenjualan.ConfigProfile
{
    public class ConfigurationProfile: Profile
    {
        public ConfigurationProfile()
        {
            CreateMap<Products, CreateProductDto>();
            CreateMap<CreateProductDto, Products>();

            CreateMap<Products, UpdateProductDto>();
            CreateMap<UpdateProductDto, Products>();

            CreateMap<Products, ProductListDto>();
            CreateMap<ProductListDto, Products>();

            CreateMap<Suppliers, CreateSupplierDto>();
            CreateMap<CreateSupplierDto, Suppliers>();

            CreateMap<Suppliers, UpdateSupplierDto>();
            CreateMap<UpdateSupplierDto, Suppliers>();

            CreateMap<Suppliers, SupplierListDto>();
            CreateMap<SupplierListDto, Suppliers>();

            CreateMap<Transactions, CreateTransactionDto>();
            CreateMap<CreateTransactionDto, Transactions>();

            CreateMap<TransactionDetails, CreateTransactionDetailDto>();
            CreateMap<CreateTransactionDetailDto, TransactionDetails>();

            CreateMap<TransactionDetails, UpdateTransactionDetailDto>();
            CreateMap<UpdateTransactionDetailDto, TransactionDetails>();

            CreateMap<TransactionDetails, TransactionDetailListDto>();
            CreateMap<TransactionDetailListDto, TransactionDetails>();
        }

    }
}
