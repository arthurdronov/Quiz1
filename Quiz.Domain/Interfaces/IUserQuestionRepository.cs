using Quiz.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Domain.Interfaces
{
	public interface IUserQuestionRepository
	{
		public Task AddPointsAsync(UserQuestion userQuestion);
		public Task<UserQuestion> CreateAsync(UserQuestion userQuestion);
		public Task<IEnumerable<UserQuestion>> GetUserQuestionsAsync();
		public Task<UserQuestion> DeleteAsync(UserQuestion userQuestion);
		public Task DeleteUserRelationAsync(int? id);
		public Task DeleteQuestionRelationAsync(int? id);
		public Task<UserQuestion> GetByIdAsync(int? id);
		public Task<bool> UserHasAnsweredCorrectly(int? userId, int? questionId);
	}
}
