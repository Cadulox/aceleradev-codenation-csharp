using System.Collections.Generic;
using System.Linq;
using Codenation.Challenge.Models;

namespace Codenation.Challenge.Services
{
    public class UserService : IUserService
    {
        private readonly CodenationContext _codenationContext;
        public UserService(CodenationContext context)
        {
            _codenationContext = context;
        }

        public IList<User> FindByAccelerationName(string name)
        {
            return _codenationContext.Candidates
                .Where(c => c.Acceleration.Name == name)
                .Select(u => u.User)
                .ToList();
        }

        public IList<User> FindByCompanyId(int companyId)
        {
            return _codenationContext.Candidates
                .Where(c => c.CompanyId == companyId)
                .Select(u => u.User).Distinct().ToList();
        }

        public User FindById(int id)
        {
            return _codenationContext.Users.FirstOrDefault(obj => obj.Id == id);
        }

        public User Save(User user)
        {
            if (user.Id == 0)
            {
                _codenationContext.Add(user);
            }
            else
            {
                _codenationContext.Users.Update(user);
            }
            
            _codenationContext.SaveChanges();
            return user;
        }
    }
}
