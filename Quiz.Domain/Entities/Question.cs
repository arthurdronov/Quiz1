using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Quiz.Domain.Entities
{
	public class Question : Entity
	{
		public string Description { get; set; }
		public string Answer { get; set; }
		public string Theme { get; set; }

		public Question(string description, string answer, string theme)
		{
			Description = description;
			Answer = answer;
			Theme = theme;
		}
		public Question(int id, string description, string answer, string theme)
		{
			Id = id;
			Description = description;
			Answer = answer;
			Theme = theme;
		}
    }
}
