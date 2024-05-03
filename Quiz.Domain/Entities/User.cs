﻿using Quiz.Domain.Validation;

namespace Quiz.Domain.Entities
{
	public class User : Entity
	{
		public string Name { get; set; }
		public int Age { get; set; }

		public User(string name, int age)
		{
			VerificarModel(name, age);
			Name = name;
			Age = age;
		}
		public User(int id, string name, int age)
		{
			VerificarModel(id, name, age);
			Id = id;
			Name = name;
			Age = age;
		}

        public void VerificarModel(int id, string name, int age)
		{
			DomainExceptionValidation.When(id < 0, "Invalid Id value");
			DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Name is required");
			DomainExceptionValidation.When(age < 3, "Minimum age is required");
			DomainExceptionValidation.When(age > 120, "Age has not a valid value");
			DomainExceptionValidation.When(age < 0, "Age has not a valid value");

		}
		public void VerificarModel(string name, int age)
		{
			DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Name is required");
			DomainExceptionValidation.When(age < 3, "Minimum age is required");
			DomainExceptionValidation.When(age > 120, "Age has not a valid value");
			DomainExceptionValidation.When(age < 0, "Age has not a valid value");

		}

	}
}
