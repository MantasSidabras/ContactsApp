using ContactsApp.Data.Contact_Repository;
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
            var x = _contactRepository.GetContacts();
            return x;
        }

        [Route("Contacts/{id}")]
        // GET: api/Contact/5
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            return Ok(_contactRepository.GetContact(id));
        }


        [Route("Contacts/Create")]
        // POST: api/Contact
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


        // DELETE: api/Contact/5
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

        [Route("Contacts/Message/{id}")]
        [HttpPost]
        public IHttpActionResult PostMessage(Message message)
        {
            if(message == null)
            {
                return BadRequest();
            }
            //SEND Message
            _contactRepository.AddMessage(message); // Adds message record to database
            return Ok(message);
        }
    }

}
