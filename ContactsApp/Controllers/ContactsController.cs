using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using ContactsApp.Data.Intefaces;
using ContactsApp.Data.Models;
using ContactsApp.Data.Contact_Repository;

namespace ContactsApp.Controllers
{
    public class ContactsController : Controller
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

        [Route("")]
        [Route("Contacts")]
        [Route("Contacts/Index")]
        public ActionResult Index()
        {
            var contactList = _contactRepository.GetContacts();
            return View(contactList);
        }

        [Route("Contacts/{id}")]
        public ActionResult Contact(int id)
        {
            var contact = _contactRepository.GetContact(id);
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
            _contactRepository.AddContact(new Contact()
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
            var contact = _contactRepository.GetContact(id);
            return View(contact);
        }

        [Route("Contacts/Edit/{id}")]
        [HttpPost]
        public ActionResult Edit(Contact contact)
        {
            _contactRepository.Update(contact);
            return Redirect("/Contacts/Index");
        }

        [Route("Contacts/Delete/{id}")]
        public ActionResult Delete(int id)
        {
            _contactRepository.DeleteContact(id);
            return Redirect("/Contacts/Index");
        }
    }
}