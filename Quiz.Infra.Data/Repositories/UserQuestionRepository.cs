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
			var user = _userQuestionContext.Users.Find(userQuestion.User.Id);
			user.Score += userQuestion.Question.Points;
			_userQuestionContext.Update(user);
			await _userQuestionContext.SaveChangesAsync();
		}

		public async Task<UserQuestion> CreateAsync(UserQuestion userQuestion)
		{
			userQuestion.UserId = userQuestion.User.Id;
			_userQuestionContext.UserQuestions.Add(userQuestion);
			await _userQuestionContext.SaveChangesAsync();
			return userQuestion;
		}
		public async Task<IEnumerable<UserQuestion>> GetUserQuestionsAsync()
		{
			return await _userQuestionContext.UserQuestions.ToListAsync();
		}
	}
}
