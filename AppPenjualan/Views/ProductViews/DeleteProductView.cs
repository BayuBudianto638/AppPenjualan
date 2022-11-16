using AppPenjualan.Application.ProductServices;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPenjualan.Views.ProductViews
{
    public class DeleteProductView
    {
        private IProductAppService _productAppService;
        private IMapper _mapper;
        public DeleteProductView(IProductAppService productAppService, IMapper mapper)
        {
            _productAppService = productAppService;
            _mapper = mapper;
        }

        public void DisplayView()
        {
            Console.Clear();
            Console.WriteLine("Delete Product");
            Console.WriteLine("--------------");
            Console.Write("Masukkan Id Product : ");
            int productId = Convert.ToInt32(Console.ReadLine());
            _productAppService.Delete(productId);
        }
    }
}
