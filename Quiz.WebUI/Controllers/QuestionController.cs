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
		public async Task<IActionResult> Create()
		{
			return View();
		}
		[HttpPost, ActionName("Create")]
		public async Task<IActionResult> Create(QuestionDTO questionDTO)
		{
			var result = _questionService.Add(questionDTO);
			TempData["success"] = "Question created successfuly";
			return RedirectToAction("Index");
		}
		public async Task<IActionResult> Answer(int? id)
		{
			var result = await _questionService.GetById(id);
			result.Answer = null;
			return View(result);
		}
		[HttpPost, ActionName("Answer")]
		public async Task<IActionResult> Answer(QuestionDTO questionDTO)
		{
			try
			{
				var result = await _questionService.VerificaResposta(questionDTO.Id, questionDTO.Answer);
				if (questionDTO == null)
				{
					return View(questionDTO);
				}
				if (!result)
				{
					TempData["error"] = "Wrong answer, try again";
					return View(questionDTO);
				}
				TempData["success"] = "Right answer, Nice!";
				return RedirectToAction("Index");
			}
			catch
			{
				return NotFound();
			}
		}
		[HttpGet]
		public async Task<IActionResult> Update(int? id)
		{
			var question = await _questionService.GetById(id);
			return View(question);
		}
		[HttpPost]
		public async Task<IActionResult> Update(QuestionDTO questionDTO)
		{
			await _questionService.Update(questionDTO);
			TempData["success"] = "Question updated successfuly";
			return RedirectToAction("Index");
		}

		[HttpGet]
		public async Task<IActionResult> Delete(int? id)
		{
			var question = await _questionService.GetById(id);
			return View(question);
		}
		[HttpPost, ActionName("Delete")]
		public async Task<IActionResult> DeletePOST(int? id)
		{
			try
			{
				if(id != null && id > 0)
				await _questionService.Remove(id);
				TempData["success"] = "Question deleted successfuly";
				return RedirectToAction("Index");
			}
			catch
			{
				return NotFound();
			}

		}
	}
}
