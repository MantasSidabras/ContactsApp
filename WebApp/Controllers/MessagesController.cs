using ContactsApp.Data.Intefaces;
using ContactsRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using ContactsApp.Data.ContactRepository;

namespace ContactsApp.Api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class MessagesController : ApiController
    {
        private readonly IContactRepository _contactRepository;

        public MessagesController()
        {
            _contactRepository = new ContactRepository();
        }

        [Route("Messages")]
        [HttpGet]
        public IHttpActionResult GetMessages()
        {
            var x = _contactRepository.GetMessages();
            return Ok(x);
        }

        [Route("Messages")]
        [HttpPost]
        public IHttpActionResult PostMessage([FromBody]Message message)
        {
            if (message == null)
            {
                return BadRequest();
            }
            //SEND Message
            _contactRepository.AddMessage(message); // Adds message record to database
            return Ok(message);
        }
        
        [Route("Messages")]
        [HttpDelete]
        public IHttpActionResult DeleteMessage(int id)
        {
            var msg = _contactRepository.GetMessage(id);
            if (msg == null)
            {
                return BadRequest();
            }
            _contactRepository.DeleteMessage(id);
            return Ok();
        }
    }
}
