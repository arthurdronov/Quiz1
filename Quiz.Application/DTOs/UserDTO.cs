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
		[MinLength(3)]
		[MaxLength(100)]
		public string Name { get; set; }
		[Required(ErrorMessage = ("Name is Required"))]
		[Range(3,100, ErrorMessage = "Minimum age required")]
		public int Age { get; set; }
	}
}
