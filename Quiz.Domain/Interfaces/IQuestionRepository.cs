using Quiz.Domain.Entities;

namespace Quiz.Domain.Interfaces
{
	public interface IQuestionRepository
	{
		public Task<IEnumerable<Question>> GetQuestionsAsync();
		public Task<Question> GetByIdAsync(int? id);

		public Task<Question> CreateAsync(Question question);
		public Task<Question> RemoveAsync(Question question);
		public Task<Question> UpdateAsync(Question question);
	}
}
