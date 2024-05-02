using Quiz.Domain.Entities;

namespace Quiz.Domain.Interfaces
{
	public interface IUserRepository
	{
		public Task<IEnumerable<User>> GetUsersAsync();
		public Task<User> GetByIdAsync(int? id);
		public Task<User> CreateAsync(User question);
		public Task<User> RemoveAsync(User question);
		public Task<User> UpdateAsync(User question);
	}
}
