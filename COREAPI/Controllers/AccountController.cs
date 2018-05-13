using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using COREAPI.DATA;
using COREAPI.Models;
using COREAPI.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace COREAPI.Controllers
{
    public class AccountController : Controller
    {
        private readonly NUAGEDbContext _dbContext;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        public AccountController(
             UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<ApplicationRole> roleManager,
            NUAGEDbContext dbContext
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _dbContext = dbContext;
            _roleManager = roleManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            try
            {
                //var list = _userManager.Users.ToList();
                //var role = new ApplicationRole();
                //role.Name = "Admin";
                //var d = await _roleManager.CreateAsync(role);
                return Json(new { Status = "" });
            }
            catch (Exception e)
            {

                throw;
            }
        }

        [HttpPost("api/user/login")]
        public async Task<IActionResult> Login([FromBody]LoginModel model)
        {
            if (ModelState.IsValid)
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    var user = await _userManager.FindByEmailAsync(model.Email);
                    var role = _userManager.GetRolesAsync(user).Result[0];
                    var claim = new[] {
                        new Claim(ClaimTypes.Name, user.UserName),
                        new Claim(ClaimTypes.Email, user.Email),
                        new Claim("UserID", user.Id.ToString()),
                        new Claim("Role", role),
                };
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("neeraj.rai18@gamil.com_nj8010077090"));
                    var signInCredential = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
                    var tokenString = new JwtSecurityToken(
                        issuer: "http://localhost:51498/",
                        audience: "http://localhost:51498/",
                        expires: DateTime.Now.AddHours(1),
                        claims: claim,
                        signingCredentials: signInCredential
                        );
                    var token = new JwtSecurityTokenHandler().WriteToken(tokenString);
                    return Json(new { Status = token });
                }
                else
                {
                    return StatusCode(500, "User Name or Password Incorrect.");
                }
            }
            return StatusCode(500, "User Name or Password Incorrect.");
        }
        [HttpPost("api/user/registration")]
        public async Task<IActionResult> Registration([FromBody] RegistrationModel model)
        {

            var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                try
                {
                    IdentityResult roleResult;
                    var roleExist = await _roleManager.RoleExistsAsync("Admin");
                    if (!roleExist)
                    {
                        //create the roles and seed them to the database
                        var role = new ApplicationRole();
                        role.Name = "Admin";
                        roleResult = await _roleManager.CreateAsync(role);
                    }
                    await _userManager.AddToRoleAsync(user, "Admin");
                    return Ok(200);
                }
                catch (Exception e)
                {
                    return StatusCode(500, e.Message);
                }
            }
            else
            {
                var error = result.Errors.Select(x => x.Description).FirstOrDefault();
                return StatusCode(500, error);
            }

        }
    }
}