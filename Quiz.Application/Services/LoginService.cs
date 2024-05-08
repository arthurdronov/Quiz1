using AutoMapper;
using Quiz.Application.DTOs;
using Quiz.Application.Interfaces;
using Quiz.Domain.Interfaces;
using Quiz.WebUI.Helper;

namespace Quiz.Application.Services
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository _loginRepository;
        private readonly IMapper _mapper;
        public LoginService(ILoginRepository loginRepository, IMapper mapper)
        {
            _loginRepository = loginRepository;
            _mapper = mapper;
        }

        public async Task<LoginDTO> GetByLogin(string loginDTO)
        {
            var user = await _loginRepository.GetByLoginAsync(loginDTO);
            return _mapper.Map<LoginDTO>(user);
        }

        public async Task<bool> IsUserValid(LoginDTO loginDTO)
        {
            var user = await _loginRepository.GetByLoginAsync(loginDTO.Login);
            if(user != null)
            {
                if(user.Password == loginDTO.Password.GenerateHash())
                {
                    return true;
                }
            }
            return false;
        }
    }
}
