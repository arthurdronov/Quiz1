using Quiz.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Quiz.Application.DTOs
{
	public class UserQuestionDTO
	{
		[Key]
		public int Id { get; set; }
		public virtual UserDTO? User { get; set; }
		public int? UserId { get; set; }
		public virtual QuestionDTO? Question { get; set; }
		public int? QuestionId { get; set; }
		public string Answer { get; set; }
		public bool? DidCorrect { get; set; }
	}
}
