using Newtonsoft.Json;
using Quiz.Application.DTOs;

namespace Quiz.WebUI.Helper
{
    public class Sessao : ISessao
    {
        private readonly IHttpContextAccessor _httpContext;
        public Sessao(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }
        public void CreateUserSession(LoginDTO loginDTO)
        {
            string usuarioJson = JsonConvert.SerializeObject(loginDTO);
            _httpContext.HttpContext.Session.SetString("sessaoUsuarioLogado", usuarioJson);
        }

        public LoginDTO GetUserSession()
        {
            string userSession = _httpContext.HttpContext.Session.GetString("sessaoUsuarioLogado");
            if (string.IsNullOrEmpty(userSession)) return null;

            return JsonConvert.DeserializeObject<LoginDTO>(userSession);
        }

        public void RemoveUserSession()
        {
            _httpContext.HttpContext.Session.Remove("sessaoUsuarioLogado");
        }
    }
}
