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
using WebApp.Message_Managment;
using System.Threading.Tasks;
using WebApp.Models;

namespace ContactsApp.Api.Controllers
{
    [Authorize]
    //[EnableCors(origins: "*", headers: "*", methods: "*")]
    public class MessagesController : ApiController
    {
        private readonly IContactRepository _contactRepository;

        public MessagesController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        [Route("Messages")]
        [HttpGet]
        public IHttpActionResult GetMessages()
        {
            return Ok(_contactRepository.GetMessages());
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
            var smsManager = new SmsManager("sid.mantas@gmail.com", "txvyrhbl");
            // smsManager.SendMessage(_contactRepository.GetContact(message.ContactId.Value).Phone, message.Text);
            Task.Run(async () => await smsManager.SendMessageEsendex(_contactRepository.GetContact(message.ContactId.Value).Phone, message.Text));
            _contactRepository.AddMessage(message); // Adds message record to database
            return Ok(message);
        }

        [Route("Messages/Email")]
        [HttpPost]
        public IHttpActionResult PostEmail([FromBody]Message message)
        {
            if (message == null)
            {
                return BadRequest();
            }

            var emailer = new SendGridEmailer("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");

            var contact = _contactRepository.GetContact(message.ContactId.Value);
            Task.Run(async () => await emailer.SendEmail(contact.Email, message.Subject, message.Text));
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
