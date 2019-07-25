using System;
using Task2_3;

namespace Task2_5
{
	class Program
	{
		static void Main(string[] args)
		{
			Employee employee = new Employee(1, "Student", "Denis", "Andriyanov", "Alexandrovich", DateTime.Parse("08.07.1999"));
			Console.WriteLine("Name: {0}", employee.Name);
			Console.WriteLine("Surname: {0}", employee.Surname);
			Console.WriteLine("Patronymic: {0}", employee.Patronymic);
			Console.WriteLine("Birthdate: {0:dd.MM.yyyy}", employee.Birthdate);
			Console.WriteLine("Position: {0}", employee.Position);
			Console.WriteLine("Expirience: {0}", employee.Expirience);
		}
	}

	class Employee : User
	{
		private int expirience;
		public int Expirience
		{
			get => expirience;
			set
			{
				if (value >= 0)
					expirience = value;
				else throw new ArgumentException("Wrong argument: expirience of employee cannot be negative.");
			}
		}

		private string position;
		public string Position
		{
			get => position;
			set
			{
				if (value != "")
					position = value;
				else throw new ArgumentException("Wrong argument: position cannot be empty");
			}
		}

		public Employee(int Expirience, string Position, string Name, string Surname, string Patronymic, DateTime Birthdate) : base (Name, Surname, Patronymic, Birthdate)
		{
			this.Expirience = Expirience;
			this.Position = Position;
		}
	}
}
