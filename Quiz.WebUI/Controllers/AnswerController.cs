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
		public async Task<IActionResult> Index(int? questionid)
		{
			var obj = new UserQuestionDTO
			{
				User = await _userService.GetById(_sessao.GetUserSession().Id),
				Question = await _questionService.GetById(questionid),
			};
			return View(obj);
		}
		[HttpPost]
		public async Task<IActionResult> Index(UserQuestionDTO userQuestionDTO)

		{
			try
			{
				var question = await _questionService.GetById(userQuestionDTO.QuestionId);

				if (userQuestionDTO.Answer == null)
				{
					TempData["error"] = "Answer is required";
					return View(userQuestionDTO);
				}
				if (userQuestionDTO.Answer.ToLower() != question.Answer.ToLower())
				{
					TempData["error"] = "Wrong Answer! Try again.";
					return View(userQuestionDTO);

				}
				userQuestionDTO.DidCorrect = true;
				//userQuestionDTO.User = await _userService.GetById(_sessao.GetUserSession().Id);
				userQuestionDTO.UserId = (_sessao.GetUserSession().Id);
				if (ModelState.IsValid)
				{
					await _userQuestionService.AddPoints(userQuestionDTO);
					await _userQuestionService.Add(userQuestionDTO);
					TempData["success"] = $"Nice, right answer!";
					return RedirectToAction("Index", "Question");

				}
				TempData["error"] = "Model state is not valid";
				return View(userQuestionDTO);
			}
			catch
			{
				TempData["error"] = "An unexpected error occurred. Please try again.";
				return View(userQuestionDTO);
			}
		}
	}
}
