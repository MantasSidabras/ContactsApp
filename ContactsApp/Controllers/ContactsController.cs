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

        private static IContactAccess contactAccess;
        //public ContactsController(IContactAccess contactAccess)
        //{
        //    this.contactAccess = contactAccess;
        //}

        public ContactsController()
        {
            if (contactAccess == null)
                contactAccess = new ContactAccess();
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

        [Route("Contacts/Create")]
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [Route("Contacts/Create")]
        [HttpPost]
        public ActionResult Create(Contact contact)
        {
            contactAccess.AddContact(new Contact()
            {
                FirstName = contact.FirstName,
                LastName = contact.LastName,
                Email = contact.Email,
                Phone = contact.Phone
            });
            return Redirect("/Contacts/Index");
        }

        [Route("Contacts/Edit/{id}")]
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var contact = contactAccess.GetContact(id);
            return View(contact);
        }

        [Route("Contacts/Edit/{id}")]
        [HttpPost]
        public ActionResult Edit(Contact contact)
        {
            contactAccess.GetContacts()[contact.Id] = contact;
            return Redirect("/Contacts/Index");
        }

        [Route("Contacts/Delete/{id}")]
        public ActionResult Delete(int id)
        {
            contactAccess.DeleteContact(id);
            return Redirect("/Contacts/Index");
        }
    }
}