using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COREAPI.Services.Imp
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork unitOfWork;
        public ProductService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
    }
}
