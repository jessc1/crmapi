
namespace crmAPI.Models
{
    public class Company
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Industry { get; set; }
        public required string WebSite { get; set; }
        public  ICollection<Contact> Contacts { get; set; }

        public static implicit operator Company(string v)
        {
            throw new NotImplementedException();
        }
    }
}