using ContactsApp.Data.ContactRepository;
using ContactsApp.Data.Intefaces;
using ContactsRepository;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;


namespace WebApp.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ContactsController : ApiController
    {
        private readonly IContactRepository _contactRepository;

        public ContactsController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        //public ContactsController()
        //{
        //    _contactRepository = new ContactRepository();
        //}

        [Authorize]
        [Route("Contacts")]
        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok(_contactRepository.GetContacts());
        }

        [Route("Contacts/{id}")]
        [HttpGet]

        public IHttpActionResult Get(int id)
        {
            return Ok(_contactRepository.GetContact(id));
        }


        [Route("Contacts/Create")]
        [HttpPost]
        public IHttpActionResult Post([FromBody]Contact value)
        {
            if (value == null)
            {
                return BadRequest();
            }

            _contactRepository.AddContact(value);
            return Ok();
        }

        [Route("Contacts/Update")]
        [HttpPut]
        public IHttpActionResult Put(Contact contact)
        {
            if (contact == null)
            {
                return BadRequest();
            }
            _contactRepository.Update(contact);
            return Ok(contact);
        }

        [Route("Contacts/Delete/{id}")]
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var contact = _contactRepository.GetContact(id);
            if (contact == null)
            {
                return BadRequest();
            }
            _contactRepository.DeleteContact(id);
            return Ok(contact);
        }



    }

}
