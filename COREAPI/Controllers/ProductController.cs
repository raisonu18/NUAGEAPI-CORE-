using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using COREAPI.Models;
using COREAPI.Services;
using COREAPI.Services.Imp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace COREAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Product"), Authorize]
    public class ProductController : Controller
    {
        private readonly IProductService productService;
        public ProductController(IProductService product)
        {
            productService = product;
        }
        [Route("Create"), HttpPost]
        [HttpOptions]
        public void CreateProduct([FromBody]ProductModel model)
        {
            try
            {
                productService.CreateProduct(model);
            }
            catch (ApiException)
            {
                throw;
            }
            catch (Exception exception)
            {
                throw new ApiException(exception.GetExceptionMessage());
            }
        }
        [Route("list"), HttpGet]
        [HttpOptions]
        public IEnumerable<ProductModel> GetProducts()
        {
            try
            {
                return productService.GetProducts();
            }
            catch (ApiException)
            {
                throw;
            }
            catch (Exception exception)
            {
                throw new ApiException(exception.GetExceptionMessage());
            }
        }
        [Route("edit/{id:int}"), HttpGet]
        [HttpOptions]
        public ProductModel EditProducts(int id)
        {
            try
            {
                return productService.EditProducts(id);
            }
            catch (ApiException)
            {
                throw;
            }
            catch (Exception exception)
            {
                throw new ApiException(exception.GetExceptionMessage());
            }
        }
        [Route("update"), HttpPost]
        [HttpOptions]
        public void UpdateProduct([FromBody]ProductModel model)
        {
            try
            {
                productService.UpdateProduct(model);
            }
            catch (ApiException)
            {
                throw;
            }
            catch (Exception exception)
            {
                throw new ApiException(exception.GetExceptionMessage());
            }
        }
    }
}