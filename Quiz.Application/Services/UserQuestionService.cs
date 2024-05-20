using AutoMapper;
using Quiz.Application.DTOs;
using Quiz.Application.Interfaces;
using Quiz.Domain.Entities;
using Quiz.Domain.Interfaces;

namespace Quiz.Application.Services
{
	public class UserQuestionService : IUserQuestionService
	{
		private readonly IUserQuestionRepository _userQuestionRepository;
		private readonly IMapper _mapper;
		public UserQuestionService(IUserQuestionRepository userQuestionRepository, IMapper mapper)
		{
			_userQuestionRepository = userQuestionRepository;
			_mapper = mapper;
		}

		public async Task Add(UserQuestionDTO userQuestionDTO)
		{
			var user = _mapper.Map<UserQuestion>(userQuestionDTO);
			await _userQuestionRepository.CreateAsync(user);
		}

		public async Task AddPoints(UserQuestionDTO userQuestionDTO)
		{
			var user = _mapper.Map<UserQuestion>(userQuestionDTO);
			await _userQuestionRepository.AddPointsAsync(user);
		}

		public async Task Remove(int? id)
		{
			var user = await _userQuestionRepository.GetByIdAsync(id);
			await _userQuestionRepository.DeleteAsync(user);
			
		}

		public async Task RemoveQuestionRelation(int? id)
		{
			await _userQuestionRepository.DeleteQuestionRelationAsync(id);
		}

		public async Task RemoveUserRelation(int? id)
		{
			await _userQuestionRepository.DeleteUserRelationAsync(id);

		}

		public async Task<bool> UserHasAnsweredCorrectly(int? userId, int? questionId)
		{
			var result = await _userQuestionRepository.UserHasAnsweredCorrectly(userId, questionId);
			return result;
		}
	}
}
