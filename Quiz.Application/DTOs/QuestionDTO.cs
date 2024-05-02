using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Application.DTOs
{
	public class QuestionDTO
	{
		public int Id { get; set; }
		[Required(ErrorMessage = "Question is Required")]
		[MinLength(8)]
		[MaxLength(150)]
		public string Description { get; set; }
		[Required(ErrorMessage = ("Answer is Required"))]
		[MinLength(1)]
		[MaxLength(100)]
		public string Answer { get; set; }
		[Required(ErrorMessage = "Theme is Required")]
		[MinLength(4)]
		[MaxLength(20)]
		public string Theme { get; set; }
		public bool? Resolved { get; set; }
	}
}
