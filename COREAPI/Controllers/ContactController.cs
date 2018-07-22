using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using COREAPI.DATA;
using COREAPI.DATA.Domain;
using COREAPI.Models;
using COREAPI.Services;
using COREAPI.Services.Imp;
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
        private readonly IContactService contactService;
        public ContactController(IContactService contact)
        {
            contactService = contact;
        }
        [Route("Create"),HttpPost]
        [HttpOptions]
        public void CreateContact([FromBody]ContactModel model)
        {
            try
            {
                contactService.CreateContact(model);
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
        public IEnumerable<ContactModel> GetContacts()
        {
            try
            {
               return contactService.GetContacts();
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