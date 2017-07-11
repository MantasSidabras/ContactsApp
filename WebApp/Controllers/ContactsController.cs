using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ContactsApp.Data.Intefaces;
using ContactsApp.Data.Contact_Repository;
using ContactsApp.Data.Models;
using System.Web.Http.Cors;

namespace WebApp.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ContactsController : ApiController
    {

        private readonly IContactRepository _contactRepository;

        //public ContactsController(IContactRepository contactRepository)
        //{
        //    _contactRepository = contactRepository;
        //}

        public ContactsController()
        {
            _contactRepository = new ContactRepository();
        }

        [Route("Contacts")]
        // GET: api/Contact
        [HttpGet]
        public IEnumerable<Contact> Get()
        {
            return _contactRepository.GetContacts();
        }

        [Route("Contacts/{id}")]
        // GET: api/Contact/5
        [HttpGet]
        public Contact Get(int id)
        {
            return _contactRepository.GetContact(id);
        }

        
        [Route("Contacts/Create")]
        // POST: api/Contact
        [HttpPost]
        public void Post([FromBody]Contact value)
        {
            _contactRepository.AddContact(value);
        }

        // PUT: api/Contact/5
        [HttpPut]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Contact/5
        [Route("Contacts/Delete/{id}")]
        [HttpDelete]
        public void Delete(int id)
        {
            _contactRepository.DeleteContact(id);
        }
    }
}
