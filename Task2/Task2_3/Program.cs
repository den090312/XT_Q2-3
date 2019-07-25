using System;

namespace Task2_3
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.Write("Enter name: ");
			string Name = Console.ReadLine();
			if (Name == "")
			{
				Console.WriteLine("Incorrect data entered.");
				return;
			}
			Console.Write("Enter last name: ");
			string Surname = Console.ReadLine();
			if (Surname == "")
			{
				Console.WriteLine("Incorrect data entered.");
				return;
			}
			Console.Write("Enter middle name: ");
			string Patronymic = Console.ReadLine();
			if (Patronymic == ""){
				Console.WriteLine("Incorrect data entered.");
				return;
			}
			Console.Write("Enter the date of birth in the format dd.mm.yyyy: ");
			if (!DateTime.TryParse(Console.ReadLine(), out DateTime Birthdate))
			{
				Console.WriteLine("Incorrect data entered.");
				return;
			}
			User user = new User(Name, Surname, Patronymic, Birthdate);
			Console.WriteLine("The age of {0} {1} {2}: {3}", user.Surname, user.Name, user.Patronymic, user.Age);
		}
	}

	public class User
	{
		private string name;
		private string surname;
		private string patronymic;

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

		public DateTime Birthdate { private set; get; }

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
