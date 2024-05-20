using Microsoft.EntityFrameworkCore;
using Quiz.Domain.Entities;
using Quiz.Domain.Interfaces;
using Quiz.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Infra.Data.Repositories
{
	public class UserQuestionRepository : IUserQuestionRepository
	{
        private readonly ApplicationDbContext _userQuestionContext;
        public UserQuestionRepository(ApplicationDbContext userQuestionContext)
        {
            _userQuestionContext = userQuestionContext;
        }

		public async Task AddPointsAsync(UserQuestion userQuestion)
		{
			var user = _userQuestionContext.Users.Find(userQuestion.UserId);
			var question = _userQuestionContext.Questions.Find(userQuestion.QuestionId);
			if(user != null && question != null)
			{
				user.Score += question.Points;
			}
			_userQuestionContext.Users.Update(user);
			await _userQuestionContext.SaveChangesAsync();
		}

		public async Task<UserQuestion> CreateAsync(UserQuestion userQuestion)
		{
			_userQuestionContext.UserQuestions.Add(userQuestion);
			await _userQuestionContext.SaveChangesAsync();
			return userQuestion;
		}

		public async Task<UserQuestion> DeleteAsync(UserQuestion userQuestion)
		{
			_userQuestionContext.UserQuestions.Remove(userQuestion);
			await _userQuestionContext.SaveChangesAsync();
			return userQuestion;
		}

		public async Task DeleteQuestionRelationAsync(int? id)
		{
			if (id != null)
			{
				if (id != null)
				{
					var result = await _userQuestionContext.UserQuestions
						.Where(c => c.QuestionId == id)
						.ToListAsync();

					_userQuestionContext.RemoveRange(result);

					await _userQuestionContext.SaveChangesAsync();
				}
			}
		}

		public async Task DeleteUserRelationAsync(int? id)
		{
			if(id != null)
			{
				var result = await _userQuestionContext.UserQuestions
					.Where(c => c.UserId == id)
					.ToListAsync();

				_userQuestionContext.RemoveRange(result);

				await _userQuestionContext.SaveChangesAsync();
			}
		}

		public async Task<UserQuestion> GetByIdAsync(int? id)
		{
			return await _userQuestionContext.UserQuestions.FindAsync(id);
		}

		public async Task<IEnumerable<UserQuestion>> GetUserQuestionsAsync()
		{
			return await _userQuestionContext.UserQuestions.ToListAsync();
		}

		public async Task<bool> UserHasAnsweredCorrectly(int? userId, int? questionId)
		{
			return await _userQuestionContext.UserQuestions
								 .AnyAsync(uq => uq.UserId == userId && uq.QuestionId == questionId && uq.DidCorrect == true);
		}

	}
}
