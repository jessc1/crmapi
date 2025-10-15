using crmAPI.Models;

namespace crmAPI.Repositories
{
    public interface IContactRepository
    {
        List<Contact> GetContacts();
        Contact GetContactById(int id);
        void AddContact(Contact contact);
        void UpdateContact(int id, Contact contact);
        void DeleteContact(int id);
        void First();    
        
    }    
    
}





