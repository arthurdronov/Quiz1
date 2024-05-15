using Microsoft.EntityFrameworkCore;
using Quiz.Domain.Entities;
using Quiz.Domain.Interfaces;
using Quiz.Infra.Data.Context;

namespace Quiz.Infra.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _userContext;
        public UserRepository(ApplicationDbContext userContext)
        {
            _userContext = userContext;

        }

        public async Task<User> CreateAsync(User user)
        {
            user.DataCadastro = DateTime.Now;
            user.Score = 0;
            user.SetPasswordHash();
            _userContext.Users.Add(user);
            await _userContext.SaveChangesAsync();
            return user;
        }

        public async Task<User> GetByIdAsync(int? id)
        {
            return await _userContext.Users.FindAsync(id);
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _userContext.Users.ToListAsync();
        }

        public async Task<User> RemoveAsync(User user)
        {
            _userContext.Users.Remove(user);
            await _userContext.SaveChangesAsync();
            return user;
        }

        public async Task<User> UpdateAsync(User user)
        {
            _userContext.Users.Update(user);
            await _userContext.SaveChangesAsync();
            return user;
        }
	}
}
