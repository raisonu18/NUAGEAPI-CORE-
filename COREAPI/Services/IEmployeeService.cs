using COREAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COREAPI.Services
{
    public interface IEmployeeService
    {
        void CreateEmployee([FromBody]EmployeeModel model);
        IEnumerable<EmployeeModel> Getemployee();
        EmployeeModel EditEmployee(int id);
    }
}
