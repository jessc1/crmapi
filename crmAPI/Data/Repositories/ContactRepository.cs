using crmAPI.Controllers;
using crmAPI.Models;

namespace crmAPI.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly List<Contact> _contactsRepository = [];
        
        public ContactRepository(List<Contact> contactsRepository)
        {
            _contactsRepository = contactsRepository;
            
        }
        public List<Contact> GetContacts()
        {
            return new List<Contact>
            {
                new Contact {
                    Id = 1,
                    FirstName = "Yi",
                    LastName = "Cheng",
                    Email = "chengyi@email.com",
                    Phone = "11912345678",
                    CompanyId = 1,
                    Company = "IQYI"
                },
                 new Contact {
                    Id = 2,
                    FirstName = "Yilun",
                    LastName = "Fang",
                    Email = "fangyilun@email.com",
                    Phone = "11985858686",
                    CompanyId = 1,
                    Company = "IQYI"
                },

            };
        }
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
