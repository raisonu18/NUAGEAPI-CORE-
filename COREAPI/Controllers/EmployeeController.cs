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
    [Route("api/Employee"), Authorize]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService employeeService;
        public EmployeeController(IEmployeeService employee)
        {
            employeeService = employee;
        }
        [Route("Create"), HttpPost]
        [HttpOptions]
        public void CreateEmployee([FromBody]EmployeeModel model)
        {
            try
            {
                employeeService.CreateEmployee(model);
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
        public IEnumerable<EmployeeModel> Getemployee()
        {
            try
            {
                return employeeService.Getemployee();
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