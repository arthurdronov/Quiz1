using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Quiz.Application.DTOs;

namespace Quiz.WebUI.ViewComponents
{
    public class Menu : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            string userSession = HttpContext.Session.GetString("sessaoUsuarioLogado");

            if(string.IsNullOrEmpty(userSession))
            {
                return null;
            }

            LoginDTO loginDTO = JsonConvert.DeserializeObject<LoginDTO>(userSession);

            return View(loginDTO);
        }
    }
}
