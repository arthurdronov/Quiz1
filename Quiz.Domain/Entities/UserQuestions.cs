using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Domain.Entities
{
    public class UserQuestions : Entity
    {
        public IEnumerable<User> User { get; set; }
        public int User_Id { get; set; }
        public IEnumerable<Question> Question { get; set; }
        public int Question_Id { get; set;}
    }
}
