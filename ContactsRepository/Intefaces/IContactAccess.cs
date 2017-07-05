using ContactsApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp.Data.Intefaces
{
    public interface IContactAccess
    {
        Contact AddContact(Contact contact);
        void DeleteContact(int index);
        Contact GetContact(int index);
        IDictionary<int, Contact> GetContacts();
        void Update(Contact contact);
    }
}
