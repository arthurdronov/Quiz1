using Quiz.Application.DTOs;

namespace Quiz.Application.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDTO>> GetUsers();
        Task<UserDTO> GetById(int? id);

        Task Add(UserDTO questionDto);
        Task Update(UserDTO questionDto);
        Task Remove(int? id);
    }
}
