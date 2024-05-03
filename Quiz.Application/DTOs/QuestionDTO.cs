using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Quiz.Application.DTOs
{
	public class QuestionDTO
	{
		public int Id { get; set; }
		[Required(ErrorMessage = "Question is Required")]
		[MinLength(1)]
		[MaxLength(150)]
		public string Description { get; set; }
		[Required(ErrorMessage = ("Answer is Required"))]
		[MinLength(1)]
		[MaxLength(100)]
		public string Answer { get; set; }
		[Required(ErrorMessage = "Theme is Required")]
		[MinLength(1)]
		[MaxLength(20)]
		public string Theme { get; set; }
	}
}
