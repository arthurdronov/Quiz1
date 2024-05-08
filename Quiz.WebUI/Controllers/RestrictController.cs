using Microsoft.AspNetCore.Mvc;
using Quiz.WebUI.Filters;

namespace Quiz.WebUI.Controllers
{
    [PagesLoggedUser]
    public class RestrictController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
