using Microsoft.EntityFrameworkCore;
using Quiz.Domain.Entities;
using Quiz.Domain.Interfaces;
using Quiz.Infra.Data.Context;

namespace Quiz.Infra.Data.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        private readonly ApplicationDbContext _loginContext;
        public LoginRepository(ApplicationDbContext loginContext)
        {
            _loginContext = loginContext;
        }

        public async Task<User> GetByLoginAsync(string login)
        {
            return await _loginContext.Users.FirstOrDefaultAsync(c => c.Login == login);
        }
    }
}
