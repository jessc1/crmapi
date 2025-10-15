using crmAPI.Models;
using crmAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace crmAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly CompanyService _companyService;

        public CompaniesController(CompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Company>> GetCompanies()
        {
            return Ok(_companyService.GetCompanies());
        }

        [HttpGet("{id}")]
        public ActionResult<Company> GetCompany(int id)
        {
            var company = _companyService.GetCompanyById(id);
            if (company == null)
                return NotFound();
            return Ok(company);
        }

        [HttpPost]
        public ActionResult<Company> CreateCompany(Company company)
        {
            _companyService.AddCompany(company);
            return NoContent();

        }

        [HttpPut("{id}")]
        public IActionResult UpdateCompany(int id, Company updateCompany)
        {
            var company = _companyService.GetCompanyById(id);
            if (company == null)
                return NotFound();
            _companyService.UpdateCompany(id, updateCompany);
            return NoContent();
        }
        public IActionResult DeleteCompany(int id)
        {
            var company = _companyService.GetCompanyById(id);
            if (company == null)
                return NotFound();
            _companyService.DeleteCompany(id);
            return NoContent();
        }
    }
}