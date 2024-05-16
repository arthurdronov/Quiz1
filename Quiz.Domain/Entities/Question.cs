using Quiz.Domain.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;
using System.Text.Json.Serialization;

namespace Quiz.Domain.Entities
{
	public class Question : Entity
	{
		public string Description { get; set; }
		public string Answer { get; set; }
		public string Theme { get; set; }
		public int Points { get; set; }

		public Question(string description, string answer, string theme)
		{
			VerificarModel(description, answer, theme);
			Description = description;
			Answer = answer;
			Theme = theme;
		}
		public Question(int id, string description, string answer, string theme)
		{
			VerificarModel(id, description, answer, theme);
			Id = id;
			Description = description;
			Answer = answer;
			Theme = theme;
		}

		public void VerificarModel(int id, string description, string answer, string theme)
		{
			DomainExceptionValidation.When(id<0, "Invalid Id value");
			DomainExceptionValidation.When(string.IsNullOrEmpty(description), "Description is required");
			DomainExceptionValidation.When(string.IsNullOrEmpty(answer), "Answer is required");
			DomainExceptionValidation.When(string.IsNullOrEmpty(theme), "Theme is required");
		}
		public void VerificarModel(string description, string answer, string theme)
		{
			DomainExceptionValidation.When(string.IsNullOrEmpty(description), "Description is required");
			DomainExceptionValidation.When(string.IsNullOrEmpty(answer), "Answer is required");
			DomainExceptionValidation.When(string.IsNullOrEmpty(theme), "Theme is required");
		}
	}
}
