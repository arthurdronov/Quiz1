using AutoMapper;
using Quiz.Application.DTOs;
using Quiz.Domain.Entities;

namespace Quiz.Application.Mappings
{
    public class DomainToDtoMappingProfile : Profile
    {
        public DomainToDtoMappingProfile()
        {
            CreateMap<Question, QuestionDTO>().ForMember(p=>p.Answer, x=>x.Ignore()).ReverseMap();
            CreateMap<UserQuestion, UserQuestionDTO>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();
        }
    }
}
