using Quiz.Domain.Enums;
using System.ComponentModel.DataAnnotations;
namespace Quiz.Application.DTOs
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "Login is Required")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Password is Required")]
        public string Password { get; set; }
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public PerfilEnum Perfil { get; set; }
        public int Age { get; set; }
    }
}
