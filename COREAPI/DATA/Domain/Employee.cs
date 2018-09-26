using COREAPI.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COREAPI.DATA.Domain
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string WhatsAppNumber { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public DateTime JoiningDate { get; set; }
        public string Designation { get; set; }
        public DateTime? RelievingDate { get; set; }
        public decimal Salary { get; set; }
        public decimal? HolidayIncentive { get; set; }
        public decimal? OverTimeIncentive { get; set; }
        public string ProfileImage { get; set; }
        public string DocumentNumber { get; set; }
        public EmployeeType EmployeeType { get; set; }
        public string UniqueId { get; set; }
    }
}
