﻿using AutoMapper;
using Quiz.Application.DTOs;
using Quiz.Application.Interfaces;
using Quiz.Domain.Entities;
using Quiz.Domain.Interfaces;
using System.Reflection.Metadata;

namespace Quiz.Application.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IMapper _mapper;
        public QuestionService(IQuestionRepository questionRepository, IMapper mapper)
        {
            _questionRepository = questionRepository;
            _mapper = mapper;
        }

        public async Task Add(QuestionDTO questionDto)
        {
            var questionEntity = _mapper.Map<Question>(questionDto);
            await _questionRepository.CreateAsync(questionEntity);

        }

        public async Task<QuestionDTO> GetById(int? id)
        {
            var questionEntity = await _questionRepository.GetByIdAsync(id);
            return _mapper.Map<QuestionDTO>(questionEntity);
        }

		public async Task<IEnumerable<QuestionDTO>> GetQuestions()
        {
            var questionsEntity = await _questionRepository.GetQuestionsAsync();
            return _mapper.Map<IEnumerable<QuestionDTO>>(questionsEntity);
        }

        public async Task Remove(int? id)
        {
            var questionEntity = await _questionRepository.GetByIdAsync(id);
            await _questionRepository.RemoveAsync(questionEntity);
        }

        public async Task Update(QuestionDTO questionDto)
        {
            var questionEntity = _mapper.Map<Question>(questionDto);
            await _questionRepository.UpdateAsync(questionEntity);
        }
    }
}
