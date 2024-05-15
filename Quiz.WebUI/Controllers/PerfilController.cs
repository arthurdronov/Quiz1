using Microsoft.AspNetCore.Mvc;
using Quiz.Application.Interfaces;
using Quiz.WebUI.Filters;

namespace Quiz.WebUI.Controllers
{
	[PagesLoggedUser]
	public class PerfilController : Controller
	{
		private readonly IPerfilService _perfilService;
        public PerfilController(IPerfilService perfilService)
        {
			_perfilService = perfilService;
		}
        public async Task<IActionResult> Index(int? id)
		{
			var perfil = await _perfilService.GetById(id);
			return View(perfil);
		}
	}
}
