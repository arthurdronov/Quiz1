using Microsoft.AspNetCore.Mvc;
using Quiz.Application.DTOs;
using Quiz.WebUI.Filters;
using Quiz.WebUI.Helper;
using Quiz.WebUI.Models;
using System.Diagnostics;

namespace Quiz.WebUI.Controllers
{
	[PagesLoggedUser]
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly ISessao _sessao;

		public HomeController(ILogger<HomeController> logger, ISessao sessao)
		{
			_logger = logger;
			_sessao = sessao;
		}

		public IActionResult Index()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
