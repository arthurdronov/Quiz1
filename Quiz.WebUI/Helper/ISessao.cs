using Quiz.Application.DTOs;

namespace Quiz.WebUI.Helper
{
    public interface ISessao
    {
        void CreateUserSession(LoginDTO usuarioDTO);
        void RemoveUserSession();
        LoginDTO GetUserSession();
    }
}
