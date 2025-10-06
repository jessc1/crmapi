namespace crmAPI.Models
{
    public class Lead
    {
        public Guid LeadId { get; set; }
        public required string FirtName { get; set; }
        public required string LastName { get; set; }
        public required string Company { get; set; }
        public required string Email { get; set; }
        public required string Phone { get; set; }
        public required string Source { get; set; } // example "Website", "Referral", "Cold Call"
        public DateTime CreatedDate { get; set; }
        public required string Status { get; set; } // example New, Contracted, Qualified and Disqualified
        public string Notes { get; set; }
        public decimal EstimatedBudget { get; set; }
        public int Priority { get; set; } // example 1 high 2 Medium 3 low

        public Lead()
        {
            LeadId = Guid.NewGuid();
            CreatedDate = DateTime.Now;
            Status = "New";
            Priority = 3;
        }

        public void QualifyLead()
        {
            Status = "Qualified";
        }
        
    }
}