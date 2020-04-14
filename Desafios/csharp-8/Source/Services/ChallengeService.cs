using System.Collections.Generic;
using System.Linq;
using Codenation.Challenge.Models;

namespace Codenation.Challenge.Services
{
    public class ChallengeService : IChallengeService
    {
        private readonly CodenationContext _codenationContext;
        public ChallengeService(CodenationContext context)
        {
            _codenationContext = context;
        }

        public IList<Models.Challenge> FindByAccelerationIdAndUserId(int accelerationId, int userId)
        {
            return _codenationContext.Candidates
                .Where(c => c.AccelerationId == accelerationId && c.UserId == userId)
                .Select(obj => obj.Acceleration.Challenge)
                .Distinct().ToList();
        }

        public Models.Challenge Save(Models.Challenge challenge)
        {
            if (challenge.Id == 0)
            {
                _codenationContext.Challenges.Add(challenge);
            }
            else
            {
                _codenationContext.Challenges.Update(challenge);
            }
            
            _codenationContext.SaveChanges();
            return challenge;
        }
    }
}