namespace crmAPI.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string Phone { get; set; }
        public int? CompanyId { get; set; }
        public required Company Company { get; set; }

    }
}