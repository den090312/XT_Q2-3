using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
			if (!DateTime.TryParse(Console.ReadLine(), out DateTime Birthdate)){
				Console.WriteLine("Неверно введены данные");
				return;
			}
			User user = new User(Name, Surname, Patronymic, Birthdate);
			Console.WriteLine("Возраст {0}а {1}а {2}а: {3}", user.Surname, user.Name, user.Patronymic, user.Age);
		}
	}

	class User
	{
		/// <summary>
		/// Имя
		/// </summary>
		public string Name { private set; get; }
		/// <summary>
		/// Фамилия
		/// </summary>
		public string Surname { private set; get; }
		/// <summary>
		/// Отчество
		/// </summary>
		public string Patronymic { private set; get; }
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
