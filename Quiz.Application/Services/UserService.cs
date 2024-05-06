using AutoMapper;
using Quiz.Application.DTOs;
using Quiz.Application.Interfaces;
using Quiz.Domain.Entities;
using Quiz.Domain.Interfaces;

namespace Quiz.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task Add(UserDTO userDto)
        {
            var userEntity = _mapper.Map<User>(userDto);
            await _userRepository.CreateAsync(userEntity);

        }

        public async Task<UserDTO> GetById(int? id)
        {
            var userEntity = await _userRepository.GetByIdAsync(id);
            return _mapper.Map<UserDTO>(userEntity);
        }

        public async Task<IEnumerable<UserDTO>> GetUsers()
        {
            var usersEntity = await _userRepository.GetUsersAsync();
            return _mapper.Map<IEnumerable<UserDTO>>(usersEntity);
        }

        public async Task Remove(int? id)
        {
            var userEntity = _userRepository.GetByIdAsync(id).Result;
            await _userRepository.RemoveAsync(userEntity);
        }

        public async Task Update(UserDTO userDto)
        {
            userDto.DataAtualizacao = DateTime.Now;
            var userEntity = _mapper.Map<User>(userDto);
            await _userRepository.UpdateAsync(userEntity);
        }
    }
}
