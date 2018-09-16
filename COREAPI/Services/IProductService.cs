using COREAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COREAPI.Services
{
    public interface IProductService
    {
        void CreateProduct([FromBody]ProductModel model);
        IEnumerable<ProductModel> GetProducts();
        ProductModel EditProducts(int id);
        void UpdateProduct([FromBody]ProductModel model);
    }
}
