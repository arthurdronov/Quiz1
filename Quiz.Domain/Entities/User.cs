using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Domain.Entities
{
    public class User : Entity
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public User(int id, string name, int age)
        {
            Id = id;
            Name = name;
            Age = age;
        }
    }
}
