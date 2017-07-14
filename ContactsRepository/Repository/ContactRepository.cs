using ContactsApp.Data.Intefaces;
using System.Collections.Generic;
using ContactsRepository;
using System.Linq;
using System;

namespace ContactsApp.Data.ContactRepository
{
    public class ContactRepository : IContactRepository
    {
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
                return _context.Contacts.ToList();
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

        public Message AddMessage(Message message)
        {
            using(_context = new ContactsDbEntities())
            {
                _context.Messages.Add(message);
                _context.SaveChanges();
            }
            return message;
        }

        public IEnumerable<Message> GetMessages()
        {
            using(_context = new ContactsDbEntities())
            {
                return _context.Messages.ToList();
            }
        }

        public Message GetMessage(int id)
        {
            using(_context = new ContactsDbEntities())
            {
                var message = (from msg in _context.Messages
                               where msg.Id == id
                               select msg).FirstOrDefault();
                return message;
            }
        }

        public void DeleteMessage(int id)
        {
            using(_context = new ContactsDbEntities())
            {
                var msgToDelete = (from msg in _context.Messages
                                   where msg.Id == id
                                   select msg).FirstOrDefault();
                _context.Messages.Remove(msgToDelete);
                _context.SaveChanges();
            }
        }

        
    }

}