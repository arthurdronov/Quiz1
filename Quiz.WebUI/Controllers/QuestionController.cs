using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Quiz.Application.DTOs;
using Quiz.Application.Interfaces;
using Quiz.Domain.Entities;

namespace Quiz.WebUI.Controllers
{
	public class QuestionController : Controller
	{
		private readonly IQuestionService _questionService;
		private readonly IMapper _mapper;
		public QuestionController(IQuestionService questionService, IMapper mapper)
		{
			_questionService = questionService;
			_mapper = mapper;
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
			return View(result);
		}
		[HttpPost, ActionName("Answer")]
		public async Task<IActionResult> Answer(QuestionDTO questionDTO)
		{

			var result = _questionService.VerificaResposta(questionDTO.Id, questionDTO.Answer).Result;
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
	}
}
