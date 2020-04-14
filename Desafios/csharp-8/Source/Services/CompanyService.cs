using System.Collections.Generic;
using System.Linq;
using Codenation.Challenge.Models;

namespace Codenation.Challenge.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly CodenationContext _codenationContext;
        public CompanyService(CodenationContext context)
        {
            _codenationContext = context;
        }

        public IList<Company> FindByAccelerationId(int accelerationId)
        {
            return _codenationContext.Candidates
                .Where(c => c.Acceleration.Id == accelerationId)
                .Select(obj => obj.Company)
                .ToList();
        }

        public Company FindById(int id)
        {
            return _codenationContext.Companies.FirstOrDefault(obj => obj.Id == id);
        }

        public IList<Company> FindByUserId(int userId)
        {
            return _codenationContext.Candidates
                .Where(c => c.UserId == userId)
                .Select(obj => obj.Company)
                .Distinct().ToList();
        }

        public Company Save(Company company)
        {

            if (company.Id == 0)
            {
                _codenationContext.Companies.Add(company);
            }
            else
            {
                _codenationContext.Companies.Update(company);
            }

            _codenationContext.SaveChanges();
            return company;
        }
    }
}