using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using COREAPI.DATA;
using COREAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace COREAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Contact"), Authorize]
    public class ContactController : Controller
    {
        private readonly NUAGEDbContext _dbContext;
        public ContactController(NUAGEDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public object CreateContact([FromBody]ContactModel model)
        {
            return Json(new { Status = "OK" });
        }
    }
}