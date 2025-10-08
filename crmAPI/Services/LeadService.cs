using crmAPI.Models;
namespace crmAPI.Services
{
    public class LeadService
    {
        private readonly List<Lead> _leads = [];

        public IEnumerable<Lead> GetLeads() => _leads;

        public Lead GetLeadById(Guid id) => _leads.First(l => l.Id == id);

        public void AddLead(Lead lead)
        {

            _leads.Add(lead);
        }
        public void UpdateLead(Guid id, Lead updateLead)
        {
            var lead = _leads.First(l => l.Id == id);
            if (_leads != null)
            {
                lead.FirtName = updateLead.FirtName;
                lead.LastName = updateLead.LastName;
                lead.Company = updateLead.Company;
                lead.Email = updateLead.Email;
                lead.Phone = updateLead.Phone;
                lead.Source = updateLead.Source;
                lead.Status = updateLead.Status;
                lead.Notes = updateLead.Notes;
                lead.EstimatedBudget = updateLead.EstimatedBudget;
                lead.Priority = updateLead.Priority;
            }
        }

        public void DeleteLead(Guid id)
        {
            var lead = _leads.First(l => l.Id == id);
            if (_leads != null)
            {
                _leads.Remove(lead);
            }
        }
        
        
    }
        
    

}