using crmAPI.Models;
using crmAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace crmAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DealsController : ControllerBase
    {
        private readonly DealService _dealService;

        public DealsController(DealService dealService)
        {
            _dealService = dealService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Deal>> GetDeals()
        {
            return Ok(_dealService.GetDeals());

        }
        [HttpGet("{id}")]
        public ActionResult<Deal> GetDeal(int id)
        {
            var deal = _dealService.GetDealById(id);
            if (deal == null)
                return NotFound();
            return Ok(deal);
        }
        [HttpPost]
        public ActionResult<Deal> CreateDeal(Deal deal)
        {
            _dealService.AddDeal(deal);
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateDeal(int id, Deal updateDeal)
        {
            var deal = _dealService.GetDealById(id);
            if (deal == null)
                return NotFound();
            _dealService.UpdateDeal(id, updateDeal);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDeal(int id)
        {
            var deal = _dealService.GetDealById(id);
            if (deal == null)
                return NotFound();
            _dealService.DeleteDeal(id);
            return NoContent();
        }
    }  
    
}
