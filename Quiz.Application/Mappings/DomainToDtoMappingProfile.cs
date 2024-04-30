using AutoMapper;
using Quiz.Application.DTOs;
using Quiz.Domain.Entities;

namespace Quiz.Application.Mappings
{
    public class DomainToDtoMappingProfile : Profile
    {
        public DomainToDtoMappingProfile()
        {
            CreateMap<Question, QuestionDTO>().ReverseMap();
        }
    }
}
