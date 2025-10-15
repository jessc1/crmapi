using crmAPI.Models;
using crmAPI.Repositories;
namespace crmAPI.Services
{
    public class ContactService: IContactService
    {
        //private readonly List<Contact> _contacts = [];
        private readonly IContactRepository _contactRepository;
        private int _nextId = 1;

        public ContactService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public List<Contact> GetContacts()
        {
            return _contactRepository.GetContacts();
        }            

        public Contact GetContactById(int id)
        {
            return _contactRepository.GetContactById(id);
        }           

        public void AddContact(Contact contact)
        {
            ArgumentNullException.ThrowIfNull(contact);
            contact.Id = _nextId++;
            _contactRepository.AddContact(contact);
        }

        public void UpdateContact(int id, Contact updateContact)
        {
            var contact = _contactRepository.GetContactById(id);
            if (_contactRepository != null)
                _contactRepository.UpdateContact(id, updateContact);
        }

        public void DeleteContact(int id)
        {
            var contact = _contactRepository.GetContactById(id);
            if (contact != null)
            {
                _contactRepository.DeleteContact(id);
            }
        }
    }
}