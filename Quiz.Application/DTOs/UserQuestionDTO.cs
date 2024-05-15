using Quiz.Domain.Entities;
using System;
using System.Collections.Generic;
namespace Quiz.Application.DTOs
{
	public class UserQuestionDTO
	{
		public int Id { get; set; }
		public UserDTO User { get; set; }
		public int? UserId { get; set; }
		public QuestionDTO Question { get; set; }
		public int? QuestionId { get; set; }
		public string Answer { get; set; }
		public bool? DidCorrect { get; set; }
	}
}
