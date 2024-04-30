using Quiz.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Application.Interfaces
{
	public interface IQuestionService
	{
		Task<IEnumerable<QuestionDTO>> GetQuestions();
		Task<QuestionDTO> GetById(int? id);

		Task Add(QuestionDTO questionDto);
		Task Update(QuestionDTO questionDto);
		Task Remove(int? id);
		Task<bool> VerificaResposta(int? id, string answer);
	}
}
