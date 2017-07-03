using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ContactsApp.Models;
using System.Text;

namespace ContactsApp.Controllers
{
    public class ContactsController : Controller
    {
        List<Contact> contacts = new List<Contact>()
            {
                new Contact(){FirstName = "Jonas", LastName = "Motiejauskas", Email = "jonas.motiejauskas@gmail.com", Phone =  "86789456"},
                new Contact(){FirstName = "Benas" },
                new Contact(){FirstName = "Povilas"}
            };

        
        // GET: Contacts
        public ActionResult Index()
        {
            string contactsString = GetContactsString(contacts);
            ViewBag.Contacts = contacts;

            return View(contacts);
        }

        public ActionResult DisplayContact(int id)
        {
            var contact = contacts[id];
            return View(contact);
        }

        private string GetContactsString(IEnumerable<Contact> contacts)
        {
            StringBuilder text = new StringBuilder();
            foreach (var contact in contacts)
            {
                contact.FirstName = contact.FirstName != null ? contact.FirstName : string.Empty;
                contact.LastName = contact.LastName != null ? contact.LastName : string.Empty;
                contact.Email = contact.Email != null ? contact.Email : string.Empty;
                contact.Phone = contact.Phone != null ? contact.Phone : string.Empty;

                text.Append(string.Format($"{contact.FirstName} {contact.LastName} {contact.Email} {contact.Phone} {Environment.NewLine}"));
            }
            return text.ToString();
        }
    }
}