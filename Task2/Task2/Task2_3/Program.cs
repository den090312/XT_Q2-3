using System;

namespace Task2_3
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.Write("Введите имя: ");
			string Name = Console.ReadLine();
			if (Name == "")
			{
				Console.WriteLine("Неверно введены данные");
				return;
			}
			Console.Write("Введите фамилию: ");
			string Surname = Console.ReadLine();
			if (Surname == "")
			{
				Console.WriteLine("Неверно введены данные");
				return;
			}
			Console.Write("Введите отчество: ");
			string Patronymic = Console.ReadLine();
			if (Patronymic == ""){
				Console.WriteLine("Неверно введены данные");
				return;
			}
			Console.Write("Введите дату рождения в формате dd.mm.yyyy: ");
			if (!DateTime.TryParse(Console.ReadLine(), out DateTime Birthdate))
			{
				Console.WriteLine("Неверно введены данные");
				return;
			}
			User user = new User(Name, Surname, Patronymic, Birthdate);
			Console.WriteLine("Возраст {0}а {1}а {2}а: {3}", user.Surname, user.Name, user.Patronymic, user.Age);
		}
	}

	public class User
	{
		private string name;
		private string surname;
		private string patronymic;
		/// <summary>
		/// Имя
		/// </summary>
		public string Name
		{
			set
			{
				if (value != "")
					name = value;
				else throw new ArgumentException("Wrong argument: name cannot be empty.");
			}
			get => name;
		}
		/// <summary>
		/// Фамилия
		/// </summary>
		public string Surname
		{
			set
			{
				if (value != "")
					surname = value;
				else throw new ArgumentException("Wrong argument: surname cannot be empty.");
			}
			get => surname;
		}
		/// <summary>
		/// Отчество
		/// </summary>
		public string Patronymic
		{
			set
			{
				if (value != "")
					patronymic = value;
				else throw new ArgumentException("Wrong argument: patronymic cannot be empty.");
			}
			get => patronymic;
		}
		/// <summary>
		/// Дата рождения
		/// </summary>
		public DateTime Birthdate { private set; get; }
		/// <summary>
		/// Возраст
		/// </summary>
		public int Age
		{
			get => DateTime.Now.Year - Birthdate.Year;
		}

		public User(string Name, string Surname, string Patronymic, DateTime Birthdate)
		{
			this.Name = Name;
			this.Surname = Surname;
			this.Patronymic = Patronymic;
			this.Birthdate = Birthdate;
		}
	}
}
