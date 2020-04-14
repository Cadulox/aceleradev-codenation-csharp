using System.Collections.Generic;
using System.Linq;
using Codenation.Challenge.Models;

namespace Codenation.Challenge.Services
{
    public class SubmissionService : ISubmissionService
    {
        private readonly CodenationContext _codenationContext;
        public SubmissionService(CodenationContext context)
        {
            _codenationContext = context;
        }

        public IList<Submission> FindByChallengeIdAndAccelerationId(int challengeId, int accelerationId)
        {
            return (from s in _codenationContext.Submissions
                    join u in _codenationContext.Users on s.UserId equals u.Id
                    join c in _codenationContext.Candidates on u.Id equals c.UserId
                    where s.ChallengeId == challengeId && c.AccelerationId == accelerationId
                    select s).Distinct().ToList();
        }

        public decimal FindHigherScoreByChallengeId(int challengeId)
        {
            return _codenationContext.Submissions
                .Where(s => s.ChallengeId == challengeId)
                .Max(x => x.Score);
        }

        public Submission Save(Submission submission)
        {
            Submission submissionResult = _codenationContext.Submissions
                .FirstOrDefault(s => s.UserId == submission.UserId && s.ChallengeId == submission.ChallengeId);

            if (submissionResult == null)
            {
                _codenationContext.Submissions.Add(submission);
                submissionResult = submission;
            }
            else
            {
                submissionResult.Score = submission.Score;
                submissionResult.CreatedAt = submission.CreatedAt;
            }
            
            _codenationContext.SaveChanges();
            return submissionResult;
        }
    }
}
