using ContactsApp.Data.Intefaces;
using ContactsApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContactsApp.Contact_Access
{
    public class ContactAccess : IContactAccess
    {
        private static Dictionary<int, Contact> contacts;
        private int id = 0;

        public ContactAccess()
        {
            contacts = new Dictionary<int, Contact>();
            AddContact(new Contact() { FirstName = "Jonas", LastName = "Motiejauskas", Email = "jonas.motiejauskas@gmail.com", Phone = "867894569" });
            AddContact(new Contact() { FirstName = "Benas", LastName = "Orlovas", Email = "benas.orlovas@yahoo.com", Phone = "+37061148987"});
            AddContact(new Contact() { FirstName = "Povilas", LastName = "Zvirblis", Email = "povilas.zvirblis@inbox.com", Phone="+37065478968"});
        }

        public Contact AddContact(Contact contact)
        {
            // validate contact
            bool isValid = true;
            if (!isValid)
            {
                return contact;
            }
            contact.Id = id;
            contacts.Add(id, contact);
            id += 1;
            return contact;
        }

        public void DeleteContact(int id)
        {
            contacts.Remove(id);
        }

        public Contact GetContact(int id)
        {
            return contacts[id];
        }

        public IDictionary<int, Contact> GetContacts()
        {
            return contacts;
        }

        public void Update(Contact contact)
        {
            contacts[contact.Id] = contact;
        }

    }

}