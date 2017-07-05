using ContactsApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp.Data.Intefaces
{
    public interface IContactRepository
    {
        Contact AddContact(Contact contact);
        void DeleteContact(int index);
        Contact GetContact(int index);
        IEnumerable<Contact> GetContacts();
        void Update(Contact contact);
    }
}
