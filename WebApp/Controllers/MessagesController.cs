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
using WebApp.Interfaces;

namespace ContactsApp.Api.Controllers
{
    [Authorize]
    //[EnableCors(origins: "*", headers: "*", methods: "*")]
    public class MessagesController : ApiController
    {
        private readonly IContactRepository _contactRepository;
        private readonly ISendGridEmailer _emailer;
        private readonly ISmsManager _smsManager;

        public MessagesController(IContactRepository contactRepository, ISendGridEmailer emailer, ISmsManager smsManager)
        {
            _contactRepository = contactRepository;
            _emailer = emailer;
            _smsManager = smsManager;
        }

        [Route("Messages")]
        [HttpGet]
        public IHttpActionResult GetMessages()
        {
            return Ok(_contactRepository.GetMessages());
        }

        [Route("Messages")]
        [HttpPost]
        public async Task<IHttpActionResult> PostMessageAsync([FromBody]Message message)
        {
            if (message == null)
            {
                return BadRequest();
            }
            //SEND Message
            //var smsManager = new SmsManager("sid.mantas@gmail.com", "txvyrhbl");
            // smsManager.SendMessage(_contactRepository.GetContact(message.ContactId.Value).Phone, message.Text);
            await _smsManager.SendMessage(_contactRepository.GetContact(message.ContactId.Value).Phone, message.Text);
            _contactRepository.AddMessage(message); // Adds message record to database
            return Ok(message);
        }

        [Route("Messages/Email")]
        [HttpPost]
        public async Task<IHttpActionResult> PostEmail([FromBody]Message message)
        {
            if (message == null)
            {
                return BadRequest();
            }

            //var _emailer = new SendGridEmailer("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");

            var contact = _contactRepository.GetContact(message.ContactId.Value);
            await _emailer.SendEmail(contact.Email, message.Subject, message.Text);
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
