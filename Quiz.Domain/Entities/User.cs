using Quiz.Domain.Enums;
using Quiz.Domain.Validation;
using Quiz.WebUI.Helper;

namespace Quiz.Domain.Entities
{
	public class User : Entity
	{
		public string Name { get; set; }
		public int Age { get; set; }
		public string Login { get; set; }
		public string Email { get; set; }
		public PerfilEnum Perfil { get; set; }
		public string Password { get; set; }
		public int? Score { get; set; }
		public DateTime DataCadastro { get; set; }
		public DateTime? DataAtualizacao { get; set; }

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
		public User(string login, string password)
		{
			Login = login;
			Password = password;
		}

		public User()
		{

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

		public void SetPasswordHash()
		{
			Password = Password.GenerateHash();
		}

		public void AddScore()
		{
			Score += 10;
		}

	}
}
