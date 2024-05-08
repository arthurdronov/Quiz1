using Microsoft.AspNetCore.Mvc;
using Quiz.Application.DTOs;
using Quiz.Application.Interfaces;
using Quiz.WebUI.Helper;

namespace Quiz.WebUI.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginService _loginService;
        private readonly ISessao _sessao;
        public LoginController(ILoginService loginService, ISessao sessao)
        {
            _loginService = loginService;
            _sessao = sessao;
        }
        public IActionResult Index()
        {
            //se sessao ativa, redireciona para index home
            if (_sessao.GetUserSession() != null) return RedirectToAction("Index", "Home");

            return View();
        }

        public IActionResult Logout()
        {
            _sessao.RemoveUserSession();

            return RedirectToAction("Index", "Login");
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
                        if (await _loginService.IsUserValid(loginDTO))
                        {
                            _sessao.CreateUserSession(user);
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
