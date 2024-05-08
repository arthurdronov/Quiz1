using Quiz.Application.DTOs;

namespace Quiz.Application.Interfaces
{
    public interface ILoginService
    {
        public Task<LoginDTO> GetByLogin(string loginDTO);
        public Task<bool> IsUserValid(LoginDTO loginDTO);
    }
}
