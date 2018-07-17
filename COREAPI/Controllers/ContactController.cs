using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using COREAPI.DATA;
using COREAPI.DATA.Domain;
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
        [Route("Create"),HttpPost]
        public object CreateContact([FromBody]ContactModel model)
        {
            Contact contact = new Contact();
            contact.FirstName = model.FirstName;
            contact.LastName = model.LastName;
            contact.CompanyName = model.CompanyName;
            contact.Email = model.Email;
            contact.Phone = model.Phone;
            contact.Mobile = model.Mobile;
            contact.Website = model.Website;
            contact.Address1 = model.Address1;
            contact.Address2 = model.Address2;
            contact.City = model.City;
            contact.State = model.State;
            contact.Country = model.Country;
            contact.ContactType = model.ContactType;
            _dbContext.Contacts.Add(contact);
            _dbContext.SaveChanges();
            return Json(new { Status = "OK" });
        }
    }
}