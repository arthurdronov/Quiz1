using System.ComponentModel.DataAnnotations.Schema;

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

        public UserQuestion(int userid, int questionid, string answer, bool didcorrect)
        {
            UserId = userid;
			QuestionId = questionid;
			Answer = answer;
			DidCorrect = didcorrect;
        }
        public UserQuestion()
        {
            
        }
    }
}
