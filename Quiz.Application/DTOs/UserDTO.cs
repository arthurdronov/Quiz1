using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
		[MaxLength(100, ErrorMessage = "Max required 100 characters")]
		public string Name { get; set; }
		[Required(ErrorMessage = ("Name is Required"))]
		[Range(3,120, ErrorMessage = "Age range (3, 120)")]
		public int Age { get; set; }
	}
}
