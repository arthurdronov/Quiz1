using Microsoft.AspNetCore.Mvc;
using Quiz.Application.DTOs;
using Quiz.Application.Interfaces;

namespace Quiz.WebUI.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginService _loginService;
        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Entrar(LoginDTO loginDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = await _loginService.GetByLogin(loginDTO.Login);

                    if (user != null)
                    {
                        if (_loginService.IsUserValid(loginDTO.Login, loginDTO.Password))
                        {

                            return RedirectToAction("Index", "Home");
                        }
                    }

                    TempData["error"] = "Invalid User/Password. Please, try again.";
                    return View("Index");
                }

                TempData["error"] = "Required User and Password.";
                return View("Index");
            }
            catch (Exception ex)
            {
                TempData["error"] = "Whoops, we couldn't find your user";
                return RedirectToAction("Index");
            }
        }
    }
}
