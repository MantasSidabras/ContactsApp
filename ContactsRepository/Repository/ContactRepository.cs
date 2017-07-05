using ContactsApp.Data.Intefaces;
using ContactsApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContactsApp.Contact_Access
{
    public class ContactRepository : IContactRepository
    {
        private static Dictionary<int, Contact> _contacts = new Dictionary<int, Contact>();
        private int _id = 0;

        public ContactRepository()
        {
        }

        public Contact AddContact(Contact contact)
        {
            // validate contact
            bool isValid = true;
            if (!isValid)
            {
                return contact;
            }
            contact.Id = _id;
            _contacts.Add(_id, contact);
            _id++;
            return contact;
        }

        public void DeleteContact(int id)
        {
            _contacts.Remove(id);
        }

        public Contact GetContact(int id)
        {
            return _contacts[id];
        }

        public IEnumerable<Contact> GetContacts()
        {
            return _contacts.Values;
        }

        public void Update(Contact contact)
        {
            _contacts[contact.Id] = contact;
        }

    }

}