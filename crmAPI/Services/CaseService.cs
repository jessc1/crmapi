using crmAPI.Models;
namespace crmAPI.Services
{
    public class CaseService
    {
        private readonly List<Case> _cases = [];

        public IEnumerable<Case> GetCases() => _cases;

        public Case GetCaseById(int id) =>
          _cases.First(c => c.Id == id);

        public void AddCase(Case c)
        {
            c.Id = _cases.Count + 1;
            _cases.Add(c);
        }

        public void UpdateCase(int id, Case updateCase)
        {
            var c = _cases.First(c => c.Id == id);
            if (_cases != null)
            {
                c.ContactId = updateCase.ContactId;
                c.Subject = updateCase.Subject;
                c.Status = updateCase.Status;
                c.Priority = updateCase.Priority;
                c.AgentId = updateCase.AgentId;
                c.CaseDate = updateCase.CaseDate;
                c.UpdatedCase = updateCase.UpdatedCase;
            }

        }
        public void DeleteCase(int id)
        {
            var c = _cases.First(c => c.Id == id);
            if (_cases != null)
            {
                _cases.Remove(c);
            }
        }
    }
}