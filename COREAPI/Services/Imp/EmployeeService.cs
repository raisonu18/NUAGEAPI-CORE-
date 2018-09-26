using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using COREAPI.DATA.Domain;
using COREAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace COREAPI.Services.Imp
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork unitOfWork;
        public EmployeeService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public void CreateEmployee([FromBody] EmployeeModel model)
        {
            IRepository<Employee> employeeRepository = unitOfWork.Get<Employee>();
            Employee employee = new Employee();
            employee.FirstName = model.FirstName;
            employee.LastName = model.LastName;
            employee.Email = model.Email;
            employee.Phone = model.Phone;
            employee.WhatsAppNumber = model.WhatsAppNumber;
            employee.Address1 = model.Address1;
            employee.Address2 = model.Address2;
            employee.Designation = model.Designation;
            employee.HolidayIncentive = model.HolidayIncentive;
            employee.DocumentNumber = model.DocumentNumber;
            employee.Salary = model.Salary;
            employee.OverTimeIncentive = model.OverTimeIncentive;
            employee.EmployeeType = model.EmployeeType;
            employee.JoiningDate = model.JoiningDate;
            employeeRepository.Add(employee);
            unitOfWork.SaveChanges();
        }

        public IEnumerable<EmployeeModel> Getemployee()
        {
            IRepository<Employee> employeeRepository = unitOfWork.Get<Employee>();
            var employee = employeeRepository.Query().Select(x =>
            {
                var list = new
                {
                    EmployeeID = x.EmployeeID,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Email = x.Email,
                    Phone = x.Phone,
                    EmployeeType = x.EmployeeType,
                };
                return list;
            }).ToList().Select(a => new EmployeeModel()
            {
                EmployeeID = a.EmployeeID,
                FirstName = a.FirstName,
                LastName = a.LastName,
                Email = a.Email,
                Phone = a.Phone,
                EmployeeTypeValue = a.EmployeeType.ToString(),
                EmployeeType = a.EmployeeType,
            });
            return employee;
        }
        public EmployeeModel EditEmployee(int id)
        {
            IRepository<Employee> employeeRepository = unitOfWork.Get<Employee>();
            Employee employee = employeeRepository.One(a => a.EmployeeID == id);
            EmployeeModel model = new EmployeeModel();
            if (employee != null)
            {
                model.EmployeeID = id;
                model.FirstName = employee.FirstName;
                model.LastName = employee.LastName;
                model.Email = employee.Email;
                model.Phone = employee.Phone;
                model.WhatsAppNumber = employee.WhatsAppNumber;
                model.Address1 = employee.Address1;
                model.Address2 = employee.Address2;
                model.Designation = employee.Designation;
                model.HolidayIncentive = employee.HolidayIncentive;
                model.DocumentNumber = employee.DocumentNumber;
                model.Salary = employee.Salary;
                model.OverTimeIncentive = employee.OverTimeIncentive;
                model.EmployeeType = employee.EmployeeType;
                model.EmployeeTypeValue = employee.EmployeeType.ToString();
                model.JoiningDate = employee.JoiningDate;
                model.JoiningDateString = employee.JoiningDate.ToString("MM/dd/yyy");
            }
            return model;
        }

        public void UpdateEmployee([FromBody] EmployeeModel model)
        {
            IRepository<Employee> employeeRepository = unitOfWork.Get<Employee>();
            Employee employee = employeeRepository.One(x => x.EmployeeID == model.EmployeeID);
            if (employee != null)
            {
                employee.FirstName = model.FirstName;
                employee.LastName = model.LastName;
                employee.Email = model.Email;
                employee.Phone = model.Phone;
                employee.WhatsAppNumber = model.WhatsAppNumber;
                employee.Address1 = model.Address1;
                employee.Address2 = model.Address2;
                employee.Designation = model.Designation;
                employee.HolidayIncentive = model.HolidayIncentive;
                employee.DocumentNumber = model.DocumentNumber;
                employee.Salary = model.Salary;
                employee.OverTimeIncentive = model.OverTimeIncentive;
                employee.EmployeeType = model.EmployeeType;
                employee.JoiningDate = model.JoiningDate;
                unitOfWork.SaveChanges();
            }
        }
    }
}
