using COREAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COREAPI.Services
{
    public interface IContactService
    {
        void CreateContact([FromBody]ContactModel model);
        IEnumerable<ContactModel> GetContacts();
    }
}
