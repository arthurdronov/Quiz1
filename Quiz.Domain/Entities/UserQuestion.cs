namespace Quiz.Domain.Entities
{
	public class UserQuestion : Entity
	{
        public int UserId { get; set; }
		public User User { get; set; }
		public int QuestionId { get; set; }
		public Question Question { get; set; }
		public string Answer { get; set; }
		public bool? DidCorrect { get; set; }
	}
}
