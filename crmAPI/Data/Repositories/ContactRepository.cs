using crmAPI.Controllers;
using crmAPI.Models;

namespace crmAPI.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly List<Contact> _contactsRepository = [];
        
        public ContactRepository()
        {
            var expectedCompany = new Company
            {
                Id = 1,
                Name = "IQYI",
                Industry = "TV",
                WebSite = "iqyi.com",
                Contacts = [],

            };
            _contactsRepository.Add( new Contact
            {
                Id = 1,
                FirstName = "Yi",
                LastName = "Cheng",
                Email = "chengyi@email.com",
                Phone = "11912345678",
                CompanyId = 1,
                Company = expectedCompany,


            }

            );
            
        }
        public List<Contact> GetContacts() => _contactsRepository;
       
        public Contact GetContactById(int id)
        {
            return _contactsRepository.First(c => c.Id == id);
        }

        public void AddContact(Contact contact)
        {
            _contactsRepository.Add(contact);

        }
        public void UpdateContact(int id, Contact updateContact)
        {
            var contact = _contactsRepository.First(c => c.Id == id);
            if (contact != null)
            {
                contact.FirstName = updateContact.FirstName;
                contact.LastName = updateContact.LastName;
                contact.Company = updateContact.Company;
            }
        }

        public void DeleteContact(int id)
        {
            var contact = _contactsRepository.First(c => c.Id == id);
            if (contact != null)
            {
                _contactsRepository.Remove(contact);
            }

        }
        public void First()
        {
            var contact = _contactsRepository.First();
        }
       


    }
}
