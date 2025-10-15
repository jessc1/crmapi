using crmAPI.Models;
using crmAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace crmAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CasesController : ControllerBase
    {
        private readonly CaseService _caseService;

        public CasesController(CaseService caseService)
        {
            _caseService = caseService;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Case>> GetCases()
        {
            return Ok(_caseService.GetCases());
        }
        public ActionResult<Case> GetCase(int id)
        {
            var c = _caseService.GetCaseById(id);
            if (c == null)
                return NotFound();
            return Ok(c);
        }

        [HttpPost]
        public ActionResult<Case> CreateCase(Case c)
        {
            _caseService.AddCase(c);
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCase(int id, Case updateCase)
        {
            var c = _caseService.GetCaseById(id);
            if (c == null)
                return NotFound();
            _caseService.UpdateCase(id, updateCase);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCase(int id)
        {
            var c = _caseService.GetCaseById(id);
            if (c == null)
                return NotFound();
            _caseService.DeleteCase(id);
            return NoContent();

        }  
        
    }

    

        
}
