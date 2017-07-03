using ContactsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContactsApp.Contact_Access
{
    public class ContactAccess
    {
        public IEnumerable<Contact> contacts { get; set; }

        public ContactAccess()
        {
            contacts = new List<Contact>()
            {
                new Contact(){FirstName = "Jonas", LastName = "Motiejauskas", Email = "jonas.motiejauskas@gmail.com", Phone =  "86789456"},
                new Contact(){FirstName = "Benas" },
                new Contact(){FirstName = "Povilas"}
            };
        }

    }
}