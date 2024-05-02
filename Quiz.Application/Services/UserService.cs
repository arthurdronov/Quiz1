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

        public async Task Add(UserDTO UserDto)
        {
            var UserEntity = _mapper.Map<User>(UserDto);
            await _userRepository.CreateAsync(UserEntity);

        }

        public async Task<UserDTO> GetById(int? id)
        {
            var UserEntity = await _userRepository.GetByIdAsync(id);
            return _mapper.Map<UserDTO>(UserEntity);
        }

        public async Task<IEnumerable<UserDTO>> GetUsers()
        {
            var UsersEntity = await _userRepository.GetUsersAsync();
            return _mapper.Map<IEnumerable<UserDTO>>(UsersEntity);
        }

        public async Task Remove(int? id)
        {
            var UserEntity = _userRepository.GetByIdAsync(id).Result;
            await _userRepository.RemoveAsync(UserEntity);
        }

        public async Task Update(UserDTO UserDto)
        {
            var UserEntity = _mapper.Map<User>(UserDto);
            await _userRepository.UpdateAsync(UserEntity);
        }
    }
}
