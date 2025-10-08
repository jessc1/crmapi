using crmAPI.Models;
namespace crmAPI.Services
{
    public class CompanyService
    {
        private readonly List<Company> _companies = [];
        public IEnumerable<Company> GetCompanies() => _companies;
        public Company GetCompanyById(int id) =>
            _companies.First(c => c.Id == id);

        public void AddCompany(Company company)
        {
            company.Id = _companies.Count + 1;
            _companies.Add(company);
        }

        public void UpdateCompany(int id, Company updateCompany)
        {
            var company = _companies.First(c => c.Id == id);
            if (_companies != null)
            {
                company.Name = updateCompany.Name;
                company.Industry = updateCompany.Industry;
                company.WebSite = updateCompany.WebSite;
                company.Contacts = updateCompany.Contacts;
            }


        }
        public void DeleteCompany(int id)
        {
            var company = _companies.First(c => c.Id == id);
            if (company != null)
            {
                _companies.Remove(company);
            }
        }
    }
}