using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using COREAPI.DATA;
using COREAPI.Models;
using COREAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace COREAPI.Controllers
{
    public class ValuesController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IUnitOfWork _unitOfWork;
        public ValuesController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<ApplicationRole> roleManager,
            IUnitOfWork unitOfWork
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _roleManager = roleManager;
            _unitOfWork = unitOfWork;
        }
        // GET api/values
        [HttpGet("api/user/detail"), Authorize]
        public async Task<IEnumerable<string>> Get()
        {
            try
            {
                IRepository<ApplicationUser> user = _unitOfWork.Get<ApplicationUser>();
                var users = user.Query();
                var claim = HttpContext.User.CurrentUserID();
                var list = _userManager.Users.ToList();
                var role = new ApplicationRole();
                role.Name = "Admin";
                var d = await _roleManager.GetRoleNameAsync(role);
                return new string[] { "value1", "value2" };
            }
            catch (Exception e)
            {
                throw;
            }

        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
