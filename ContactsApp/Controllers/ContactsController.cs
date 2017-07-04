using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ContactsApp.Models;
using System.Text;
using ContactsApp.Contact_Access;
using ContactsApp.Intefaces;

namespace ContactsApp.Controllers
{
    

    public class ContactsController : Controller
    {
        // GET: Contacts

        IContactAccess contactAccess;
        //public ContactsController(IContactAccess contactAccess)
        //{
        //    this.contactAccess = contactAccess;
        //}

        public ContactsController()
        {
            this.contactAccess = new ContactAccess();
        }

        [Route("")]
        [Route("Contacts")]
        [Route("Contacts/Index")]
        public ActionResult Index()
        {
            var contactList = contactAccess.GetContacts();
            return View(contactList);
        }

        [Route("Contacts/{id}")]
        public ActionResult Contact(int id)
        {
            var contact = contactAccess.GetContact(id);
            return View(contact);
        }

        public ActionResult CreateContact()
        {
            return View();
        }
    }
}