using Quiz.Infra.Data.Context;
using Quiz.Domain.Interfaces;
using Quiz.Domain.Entities;
using Microsoft.EntityFrameworkCore;

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
