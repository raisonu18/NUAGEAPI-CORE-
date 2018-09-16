using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using COREAPI.DATA.Domain;
using COREAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace COREAPI.Services.Imp
{
    public class ContactService : IContactService
    {
        private readonly IUnitOfWork unitOfWork;
        public ContactService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public void CreateContact([FromBody] ContactModel model)
        {
            IRepository<Contact> contactRepository = unitOfWork.Get<Contact>();
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
            contactRepository.Add(contact);
            unitOfWork.SaveChanges();
        }

        public IEnumerable<ContactModel> GetContacts()
        {
            IRepository<Contact> contactRepository = unitOfWork.Get<Contact>();
            var contacts = contactRepository.Query().Select(x => new
            {
                ContactID = x.ContactID,
                FirstName = x.FirstName,
                LastName = x.LastName,
                CompanyName = x.CompanyName,
                Email = x.Email,
                Phone = x.Phone,
                Mobile = x.Mobile,
                Website = x.Website,
                Address1 = x.Address1,
                Address2 = x.Address2,
                City = x.City,
                State = x.State,
                Country = x.Country,
                ContactType = x.ContactType,
            }).ToList().Select(x => new ContactModel()
            {
                ContactID = x.ContactID,
                FirstName = x.FirstName,
                LastName = x.LastName,
                CompanyName = x.CompanyName,
                Email = x.Email,
                Phone = x.Phone,
                Mobile = x.Mobile,
                Website = x.Website,
                Address1 = x.Address1,
                Address2 = x.Address2,
                City = x.City,
                State = x.State,
                Country = x.Country,
                ContactType = x.ContactType,
                ContactTypeValue = x.ContactType.ToString(),
            });
            return contacts;
        }
        public ContactModel EditContact(int id)
        {
            IRepository<Contact> contactRepository = unitOfWork.Get<Contact>();
            var contact = contactRepository.One(x => x.ContactID == id);
            ContactModel model = new ContactModel();
            if (contact != null)
            {
                model.ContactID = id;
                model.FirstName = contact.FirstName;
                model.LastName = contact.LastName;
                model.CompanyName = contact.CompanyName;
                model.Email = contact.Email;
                model.Phone = contact.Phone;
                model.Mobile = contact.Mobile;
                model.Website = contact.Website;
                model.Address1 = contact.Address1;
                model.Address2 = contact.Address2;
                model.City = contact.City;
                model.State = contact.State;
                model.Country = contact.Country;
                model.ContactType = contact.ContactType;
                model.ContactTypeValue = contact.ContactType.ToString();
            }
            return model;
        }

        public void UpdateContact([FromBody] ContactModel model)
        {
            IRepository<Contact> contactRepository = unitOfWork.Get<Contact>();
            var contact = contactRepository.One(x => x.ContactID == model.ContactID);
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
            unitOfWork.SaveChanges();
        }
    }
}
