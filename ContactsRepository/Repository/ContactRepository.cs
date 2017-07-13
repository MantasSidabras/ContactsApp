using ContactsApp.Data.Intefaces;
using System.Collections.Generic;
using ContactsRepository;
using System.Linq;

namespace ContactsApp.Data.Contact_Repository
{
    public class ContactRepository : IContactRepository
    {
        private static Dictionary<int, Contact> _contacts = new Dictionary<int, Contact>();
        //private static int _id = 0;
        private ContactsDbEntities _context;

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
            using (_context = new ContactsDbEntities())
            {
                //contact.Id = _id;
                // _id++;
                _context.Contacts.Add(contact);
                _context.SaveChanges();
            }
            return contact;
        }

        public void DeleteContact(int id)
        {
            using(_context = new ContactsDbEntities())
            {
                var contact = (from c in _context.Contacts
                               where c.Id == id
                               select c).FirstOrDefault();
                _context.Contacts.Remove(contact);
                _context.SaveChanges();
            }
        }

        public Contact GetContact(int id)
        {
            Contact contact = null;
            using (_context = new ContactsDbEntities())
            {
                contact = (from c in _context.Contacts
                               where c.Id == id
                               select c).FirstOrDefault();
            }
            return contact;
        }

        public IEnumerable<Contact> GetContacts()
        {
            using (_context = new ContactsDbEntities())
            {
                //_context.Configuration.LazyLoadingEnabled = false;
                var a = _context.Contacts.ToList();
                return a;
            }
        }

        public void Update(Contact contact)
        {
            Contact oldContact;
            using(_context = new ContactsDbEntities())
            {
                oldContact = (from c in _context.Contacts
                              where contact.Id == c.Id
                              select c).FirstOrDefault();
                oldContact.FirstName = contact.FirstName;
                oldContact.LastName = contact.LastName;
                oldContact.Email = contact.Email;
                oldContact.Phone = contact.Phone;

                _context.SaveChanges();
            }
        }

    }

}