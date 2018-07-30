using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using COREAPI.Services;
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
    }
}