using crmAPI.Models;
namespace crmAPI.Services
{
    public class DealService
    {
        private readonly List<Deal> _deals = [];
        public IEnumerable<Deal> GetDeals() => _deals;
        public Deal GetDealById(int id) =>
            _deals.First(d => d.Id == id);

        public void AddDeal(Deal deal)
        {
            deal.Id = _deals.Count + 1;
            _deals.Add(deal);
        }

        public void UpdateDeal(int id, Deal updateDeal)
        {
            var deal = _deals.First(d => d.Id == id);
            if (deal != null)
            {
                deal.Description = updateDeal.Description;
                deal.Value = updateDeal.Value;
                deal.DealDate = updateDeal.DealDate;
                deal.Seller = updateDeal.Seller;
                deal.Buyer = updateDeal.Buyer;
                deal.Status = updateDeal.Status;
                deal.Items = updateDeal.Items;
            }

        }
        public void DeleteDeal(int id)
        {
            var deal = _deals.First(d => d.Id == id);
            if (deal != null)
            {
                _deals.Remove(deal);
            }
        }
       
    }
}