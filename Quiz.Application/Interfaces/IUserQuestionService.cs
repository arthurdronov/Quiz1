using Quiz.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Application.Interfaces
{
	public interface IUserQuestionService
	{
		public Task Add(UserQuestionDTO userQuestionDTO);
		public Task Remove(int? id);
		public Task RemoveUserRelation(int? id);
		public Task RemoveQuestionRelation(int? id);
		public Task AddPoints(UserQuestionDTO userQuestionDTO);
		public Task<bool> UserHasAnsweredCorrectly(int? userId, int? questionId);
	}
}
