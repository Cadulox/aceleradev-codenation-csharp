using System.Collections.Generic;
using System.Linq;
using Codenation.Challenge.Models;

namespace Codenation.Challenge.Services
{
    public class CandidateService : ICandidateService
    {
        private readonly CodenationContext _codenationContext;
        public CandidateService(CodenationContext context)
        {
            _codenationContext = context;
        }

        public IList<Candidate> FindByAccelerationId(int accelerationId)
        {
            return _codenationContext.Candidates
                .Where(c => c.AccelerationId == accelerationId)
                .Distinct().ToList();
        }

        public IList<Candidate> FindByCompanyId(int companyId)
        {
            return _codenationContext.Candidates
                .Where(c => c.CompanyId == companyId)
                .Distinct().ToList();
        }

        public Candidate FindById(int userId, int accelerationId, int companyId)
        {
            return _codenationContext.Candidates
                .FirstOrDefault(c => c.UserId == userId && c.AccelerationId == accelerationId && c.CompanyId == companyId);
        }

        public Candidate Save(Candidate candidate)
        {
            Candidate candidateResult = FindById(candidate.UserId, candidate.AccelerationId, candidate.CompanyId);
            
            if (candidateResult == null)
            {
                _codenationContext.Candidates.Add(candidate);
                candidateResult = candidate;
            }
            else
            {
                candidateResult.Status = candidate.Status;
                candidateResult.CreatedAt = candidate.CreatedAt;
            }

            _codenationContext.SaveChanges();
            return candidateResult;
        }
    }
}
