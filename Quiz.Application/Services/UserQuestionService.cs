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
	}
}
