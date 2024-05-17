using Quiz.Domain.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;
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

		public Question(string description, string answer, string theme, int points)
		{
			VerificarModel(description, answer, theme, points);
			Description = description;
			Answer = answer;
			Theme = theme;
			Points = points;
		}
		public Question(int id, string description, string answer, string theme, int points)
		{
			VerificarModel(id, description, answer, theme, points);
			Id = id;
			Description = description;
			Answer = answer;
			Theme = theme;
			Points = points;
		}

		public void VerificarModel(int id, string description, string answer, string theme, int points)
		{
			DomainExceptionValidation.When(id<0, "Invalid Id value");
			DomainExceptionValidation.When(string.IsNullOrEmpty(description), "Description is required");
			DomainExceptionValidation.When(string.IsNullOrEmpty(answer), "Answer is required");
			DomainExceptionValidation.When(string.IsNullOrEmpty(theme), "Theme is required");
			DomainExceptionValidation.When(points < 0, "Points is required");
		}
		public void VerificarModel(string description, string answer, string theme, int points)
		{
			DomainExceptionValidation.When(string.IsNullOrEmpty(description), "Description is required");
			DomainExceptionValidation.When(string.IsNullOrEmpty(answer), "Answer is required");
			DomainExceptionValidation.When(string.IsNullOrEmpty(theme), "Theme is required");
			DomainExceptionValidation.When(points < 0, "Points is required");
		}
	}
}
