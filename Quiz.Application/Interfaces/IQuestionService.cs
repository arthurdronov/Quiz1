using Quiz.Application.DTOs;

namespace Quiz.Application.Interfaces
{
    public interface IQuestionService
    {
        Task<IEnumerable<QuestionDTO>> GetQuestions();
        Task<QuestionDTO> GetById(int? id);

		Task Add(QuestionDTO questionDto);
        Task Update(QuestionDTO questionDto);
        Task Remove(int? id);
    }
}
