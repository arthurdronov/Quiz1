using Quiz.Infra.Data.Context;
using Quiz.Domain.Interfaces;
using Quiz.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Quiz.Infra.Data.Repositories
{
	public class QuestionRepository : IQuestionRepository
	{
		private readonly ApplicationDbContext _questionContext;
		public QuestionRepository(ApplicationDbContext questionContext)
		{
			_questionContext = questionContext;

		}

		public async Task<Question> CreateAsync(Question question)
		{
			_questionContext.Questions.Add(question);
			await _questionContext.SaveChangesAsync();
			return question;
		}

		public async Task<Question> GetByIdAsync(int? id)
		{
			return await _questionContext.Questions.FindAsync(id);
		}

		public async Task<IEnumerable<Question>> GetQuestionsAsync()
		{
			return await _questionContext.Questions.ToListAsync();
		}

		public async Task<Question> RemoveAsync(Question question)
		{
			 _questionContext.Questions.Remove(question);
			await _questionContext.SaveChangesAsync();
			return question;
		}

		public async Task<Question> UpdateAsync(Question question)
		{
			_questionContext.Questions.Update(question);
			await _questionContext.SaveChangesAsync();
			return question;
		}
	}
}
