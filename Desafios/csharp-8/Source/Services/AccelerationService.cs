using System.Collections.Generic;
using System.Linq;
using Codenation.Challenge.Models;

namespace Codenation.Challenge.Services
{
    public class AccelerationService : IAccelerationService
    {
        private readonly CodenationContext _codenationContext;
        public AccelerationService(CodenationContext context)
        {
            _codenationContext = context;
        }

        public IList<Acceleration> FindByCompanyId(int companyId)
        {
            return _codenationContext.Candidates
                .Where(c => c.Company.Id == companyId)
                .Select(obj => obj.Acceleration)
                .Distinct().ToList();
        }

        public Acceleration FindById(int id)
        {
            return _codenationContext.Accelerations.FirstOrDefault(a => a.Id == id);
        }

        public Acceleration Save(Acceleration acceleration)
        {
            if (acceleration.Id == 0)
            {
                _codenationContext.Accelerations.Add(acceleration);
            }
            else
            {
                _codenationContext.Accelerations.Update(acceleration);
            }

            _codenationContext.SaveChanges();
            return acceleration;
        }
    }
}
