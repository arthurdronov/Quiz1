using Quiz.Domain.Entities;

namespace Quiz.Domain.Interfaces
{
	public interface IPerfilRepository
	{
		public Task<User> GetByIdAsync(int? id);

	}
}
