using ContactsRepository;
using System.Collections.Generic;


namespace ContactsApp.Data.Intefaces
{
    public interface IContactRepository
    {
        Contact AddContact(Contact contact);
        void DeleteContact(int index);
        Contact GetContact(int index);
        IEnumerable<Contact> GetContacts();
        void Update(Contact contact);
        Message AddMessage(Message message);
        IEnumerable<Message> GetMessages();
        Message GetMessage(int id);
        void DeleteMessage(int id);
    }
}
