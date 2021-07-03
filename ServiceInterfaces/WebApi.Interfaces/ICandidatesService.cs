using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Domain.Model;

namespace WebApi.Interfaces
{
    public interface ICandidatesService
    {
        Task<AuthenticateResponse> Authenticate(AuthenticateRequest model);
        Task<List<Candidate>> GetAll();
        Task<Candidate> UpdateCandidate(Candidate dta);
        Task<Candidate> GetById(string id);
        Task<Candidate> CreateCandidate(Candidate dto);
        Task<bool> DeleteCandidate(string id);

    }
}
