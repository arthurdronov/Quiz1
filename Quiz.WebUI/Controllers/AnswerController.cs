using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
		public async Task<IActionResult> Index(UserQuestionDTO obj)

	{
			try
			{
				var question = await _questionService.GetById(obj.QuestionId);
				var user = await _userService.GetById(_sessao.GetUserSession().Id);
				obj.UserId = user.Id;

				if (obj.Answer == null)
				{
					TempData["error"] = "Answer is required";
					return View(obj);
				}
				if (obj.Answer.ToLower() != question.Answer.ToLower())
				{
					obj.Question = question;
					TempData["error"] = "Wrong Answer! Try again.";
					return View(obj);

				}
				obj.DidCorrect = true;

				if (ModelState.IsValid)
				{
					var userHasAnsweredCorrectly = await _userQuestionService.UserHasAnsweredCorrectly(obj.UserId, obj.QuestionId);

					if (!userHasAnsweredCorrectly)
					{
						await _userQuestionService.AddPoints(obj);
						await _userQuestionService.Add(obj);
					}
					TempData["success"] = $" Nice! +{question.Points} Points";
					return RedirectToAction("Index", "Question");

				}
				TempData["error"] = "Model state is not valid";
				return View(obj);
			}
			catch (Exception ex)
			{
				throw (ex);
				//TempData["error"] = "An unexpected error occurred. Please try again.";
				//return View(obj);
			}
		}
	}
}
