using Microsoft.AspNetCore.Mvc;
using Quiz.Application.DTOs;
using Quiz.Application.Interfaces;

namespace Quiz.WebUI.Controllers
{
	public class QuestionController : Controller
	{
		private readonly IQuestionService _questionService;
		public QuestionController(IQuestionService questionService)
		{
			_questionService = questionService;
		}
		[HttpGet]
		public async Task<IActionResult> Index()
		{
			var result = await _questionService.GetQuestions();
			return View(result);
		}
		public async Task<IActionResult> Answer(int? id)
		{
			var result = await _questionService.GetById(id);
			return View(result);
		}
		[HttpPost, ActionName("Answer")]
		public async Task<IActionResult> Answer(QuestionDTO question)
		{

			var result = _questionService.VerificaResposta(question.Id, question.Answer).Result;
			if (question == null)
			{
				return View(question);
			}
			if (!result)
			{
				question.Resolved = false;
				return View(question);
			}
			question.Resolved = true;
			TempData["success"] = "Right answer, Nice!";
			return RedirectToAction("Index");
		}
	}
}
