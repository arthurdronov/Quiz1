using Microsoft.AspNetCore.Mvc;
using Quiz.Application.DTOs;
using Quiz.Application.Interfaces;
using Quiz.WebUI.Helper;

namespace Quiz.WebUI.Controllers
{
	public class AnswerController : Controller
	{
		private readonly IUserQuestionService _userQuestionService;
		private readonly IQuestionService _questionService;
		private readonly IUserService _userService;
		private readonly ISessao _sessao;
		public AnswerController(IUserQuestionService userQuestionService, ISessao sessao, 
			IUserService userService, IQuestionService questionService)
		{
			_userQuestionService = userQuestionService;
			_sessao = sessao;
			_userService = userService;
			_questionService = questionService;
		}
		[HttpGet]
		public async Task<IActionResult> Index(int? id)
		{
			var obj = new UserQuestionDTO 
			{ 
				User = await _userService.GetById(_sessao.GetUserSession().Id),
				Question = await _questionService.GetById(id)
			};
			return View(obj);
		}
		[HttpPost]
		public async Task<IActionResult> Index(UserQuestionDTO userQuestionDTO)
		{
			if(userQuestionDTO.Answer.ToLower() == userQuestionDTO.Question.Answer.ToLower())
			{
				userQuestionDTO.DidCorrect = true;
				TempData["success"] = $"Nice, right answer!";
				return RedirectToAction("Index", "Question");
			}
			return View(userQuestionDTO);
		}
	}
}
