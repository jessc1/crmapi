using crmAPI.Models;

namespace crmAPI.Services
{
    public interface IContactService
    {
        void AddContact(Contact contact);
        Contact GetContactById(int id);
        List<Contact> GetContacts();
        void UpdateContact(int id, Contact updateContact);
        void DeleteContact(int id); 

    }
}