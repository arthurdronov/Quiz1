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
			try
			{
				if (ModelState.IsValid)
				{
					await _questionService.Add(questionDTO);

					TempData["success"] = "Question created successfuly";
					return RedirectToAction("Index");
				}
				TempData["error"] = "Error create question";
				return View(questionDTO);
			}
			catch(Exception error)
			{
				TempData["error"] = $"Error question create {error.Message}";
				return View(questionDTO);
			}

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
			catch(Exception error)
			{
				return View($"Error question answer {error.Message}");
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
			try
			{
				if (ModelState.IsValid)
				{
					await _questionService.Update(questionDTO);
					TempData["success"] = "Question updated successfuly";
					return RedirectToAction("Index");
				}
				TempData["error"] = "Error question update";
				return View(questionDTO);
			}
			catch(Exception error)
			{
				TempData["error"] = $"Error question update: {error.Message}";
				return View(questionDTO);
			}
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
				if (ModelState.IsValid)
				{
					if (id != null && id > 0)
						await _questionService.Remove(id);
					TempData["success"] = "Question deleted successfuly";
					return RedirectToAction("Index");
				}
				TempData["error"] = "Error for delete a question";
				return View();
			}
			catch(Exception error)
			{
				TempData["error"] = $"Error question delete: {error.Message}";
				return View();
			}

		}
	}
}
