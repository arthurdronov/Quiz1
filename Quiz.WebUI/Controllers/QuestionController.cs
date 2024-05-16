using Microsoft.AspNetCore.Mvc;
using Quiz.Application.DTOs;
using Quiz.Application.Interfaces;
using Quiz.WebUI.Filters;
using Quiz.WebUI.Helper;

namespace Quiz.WebUI.Controllers
{
    [PagesLoggedUser]
    public class QuestionController : Controller
	{
		private readonly IQuestionService _questionService;
		public QuestionController(IQuestionService questionService, ISessao sessao)
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

		[HttpGet]
		[RestrictedPageAdmin]
		public async Task<IActionResult> Update(int? id)
		{
			try
			{
                var question = await _questionService.GetById(id);
				if(question == null)
				{
					return NotFound();	
				}
                return View(question);
            }
			catch
			{
				return NotFound();
			}

		}
		[HttpPost]
		[RestrictedPageAdmin]
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
		[RestrictedPageAdmin]
		public async Task<IActionResult> Delete(int? id)
		{
			var question = await _questionService.GetById(id);
			return View(question);
		}
		[HttpPost, ActionName("Delete")]
		[RestrictedPageAdmin]
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
