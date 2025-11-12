using crmAPI.Models;
using crmAPI.Services;
using Microsoft.AspNetCore.Mvc;
namespace crmAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactsController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Contact>> GetContacts()
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(_contactService.GetContacts());
        }
        [HttpGet("{id}")]
        public ActionResult<Contact> GetContactById(int id)
        {
            var contact = _contactService.GetContactById(id);
            if (contact == null)
                return NotFound();
            return Ok(contact);
        }
        [HttpPost]
        public ActionResult<Contact> CreateContact(Contact contact)
        {
            _contactService.AddContact(contact);
            return NoContent();

        }
        [HttpPut("{id}")]
        public IActionResult UpdateContact(int id, Contact updateContact)
        {
            var contact = _contactService.GetContactById(id);
            if (contact == null)
                return NotFound();
            _contactService.UpdateContact(id, updateContact);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteContact(int id)
        {
            var contact = _contactService.GetContactById(id);
            if (contact == null)
                return NotFound();
            _contactService.DeleteContact(id);
            return NoContent();
        }


    }
}