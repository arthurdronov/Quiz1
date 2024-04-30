using System.Reflection.Metadata;

namespace Quiz.Domain.Entities
{
	public class Question : Entity
	{
		public string Description { get; private set; }
		public string Answer { get; private set; }
		public string Theme { get; private set; }

		public Question(string description, string answer, string theme)
		{
			Description = description;
			Answer = answer;
			Theme = theme;
		}
	}
}
