namespace crmAPI.Models
{
    public class Case
    {
        public int CaseId { get; set; }
        public int ContactId { get; set; }
        public required string Subject { get; set; }
        public CaseStatus Status { get; set; }
        public int Priority { get; set; }
        public int AgentId { get; set; }
        public DateTime CaseDate { get; set; }
        public DateTime UpdatedCase { get; set; }


    }
    public enum CaseStatus
    {
        Open,
        In_PROGRESS,
        Resolved,
        Closed,
        Pending
    }
}