using Quiz.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Application.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is Required")]
        [MinLength(3, ErrorMessage = "Min required 3 characters")]
        [MaxLength(100, ErrorMessage = "Max limit 100 characters")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Age is Required")]
        [Range(3, 120, ErrorMessage = "Age range (3, 120)")]
        public int Age { get; set; }
        [Required(ErrorMessage ="Login is Required")]
        [MinLength(3, ErrorMessage = "Min required 3 characters")]
        public string Login { get; set; }
        [Required(ErrorMessage = "E-mail is Required")]
        [EmailAddress(ErrorMessage ="Invalid E-mail value")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Perfil is Required")]
        public PerfilEnum Perfil { get; set; }
        [Required(ErrorMessage = "Password is Required")]
        [MinLength(3, ErrorMessage = "Min required 3 characters")]
        [MaxLength(100, ErrorMessage = "Max limit 100 characters")]
        public string Password { get; set; }
		public int? Score { get; set; }
		public DateTime DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; }

    }
}
