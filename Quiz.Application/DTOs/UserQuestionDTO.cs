namespace Quiz.Application.DTOs
{
	public class UserQuestionDTO
	{
		public int Id { get; set; }
		public int UserId { get; set; }
		public int QuestionId { get; set; }
		public string Answer { get; set; }
	}
}
