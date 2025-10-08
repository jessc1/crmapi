namespace crmAPI.Models
{
    public class Deal
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
        public DateTime DealDate { get; set; }
        public string Seller { get; set; }
        public string Buyer { get; set; }
        public DealStatus Status { get; set; }
        public List<DealItem> Items { get; set; } = new List<DealItem>();
    }
}

public class DealItem
{
    public int ItemId { get; set; }
    public required string ProductName { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }

 }

public enum DealStatus
{
    Pending,
    Approved,
    Rejected,
    Completed,
    Cancelled
 }