using crmAPI.Models;
namespace crmAPI.Services
{
    public class ContactService
    {
        private readonly List<Contact> _contacts = [];
        public IEnumerable<Contact> GetContacts() => _contacts;

        public Contact GetContactById(int id) =>
            _contacts.First(c => c.Id == id);

        public void AddContact(Contact contact)
        {
            contact.Id = _contacts.Count + 1;
            _contacts.Add(contact);
        }

        public void UpdateContact(int id, Contact Updatecontact)
        {
            var contact = _contacts.First(c => c.Id == id);
            if (_contacts != null)
            {
                contact.FirtName = Updatecontact.FirtName;
                contact.LastName = Updatecontact.LastName;
                contact.Email = Updatecontact.Email;
                contact.Phone = Updatecontact.Phone;
                contact.CompanyId = Updatecontact.CompanyId;
                contact.Company = Updatecontact.Company;

            }
        }

        public void DeleteContact(int id)
        {
            var contact = _contacts.First(c => c.Id == id);
            if (_contacts != null)
            {
                _contacts.Remove(contact);
            }
        }
    }
}