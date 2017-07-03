using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ContactsApp.Models;
using System.Text;
using ContactsApp.Contact_Access;

namespace ContactsApp.Controllers
{
    public class ContactsController : Controller
    {   
        // GET: Contacts
        public ActionResult Index()
        {
            var contactAccess = new ContactAccess();
            var contactList = contactAccess.contacts.ToList();
            return View(contactList);
        }

        public ActionResult DisplayContact(int id)
        {
            var contactAccess = new ContactAccess();
            var contactList = contactAccess.contacts.ToList();
            return View(contactList[id]);
        }
    }
}