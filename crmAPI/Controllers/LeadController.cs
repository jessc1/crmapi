using crmAPI.Models;
using crmAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace crmAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeadController : ControllerBase
    {
        private readonly LeadService _leadService;

        public LeadController(LeadService leadService)
        {
            _leadService = leadService;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Lead>> GetLead()
        {
            return Ok(_leadService.GetLeads());
        }
        public ActionResult<Lead> GetLead(Guid id)
        {
            var lead = _leadService.GetLeadById(id);
            if (lead == null)
                return NotFound();
            return Ok(lead);
        }
        [HttpPost]
        public ActionResult<Lead> CreateLead(Lead lead)
        {
            _leadService.AddLead(lead);
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateLead(Guid id, Lead updateLead)
        {
            var lead = _leadService.GetLeadById(id);
            if (lead == null)
                return NotFound();
            _leadService.UpdateLead(id, updateLead);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteLead(Guid id)
        {
            var lead = _leadService.GetLeadById(id);
            if (lead == null)
                return NotFound();
            _leadService.DeleteLead(id);
            return NoContent();

        }         
    }       
}
