using Quiz.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Quiz.Application.DTOs
{
	public class UserQuestionDTO
	{
		[Key]
		public int Id { get; set; }
		[ValidateNever]
		public virtual UserDTO User { get; set; }
		public int? UserId { get; set; }
		[ValidateNever]
		public virtual QuestionDTO Question { get; set; }
		public int? QuestionId { get; set; }
		[Required]
		public string Answer { get; set; }
		public bool? DidCorrect { get; set; }
	}
}
