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

		public async Task<UserQuestion> CreateAsync(UserQuestion userQuestion)
		{
			_userQuestionContext.Add(userQuestion);
			await _userQuestionContext.SaveChangesAsync();
			return userQuestion;
		}
		public async Task<IEnumerable<UserQuestion>> GetUserQuestionsAsync()
		{
			return await _userQuestionContext.UserQuestions.ToListAsync();
		}
	}
}
