using System;
using BLL;
using BLL.Classes;

namespace PL
{
	class Program
	{
		static BLLMain bLL;

		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
			bLL = new BLLMain();
			while (true)
			{
				Console.WriteLine("Select an action: ");
				Console.WriteLine("============User Actions============");
				Console.WriteLine("1. View all users list.");
				Console.WriteLine("2. Add new user.");
				Console.WriteLine("3. Add award to user.");
				Console.WriteLine("4. Remove user reward.");
				Console.WriteLine("5. Delete User.");
				Console.WriteLine("===============Reward Actions==============");
				Console.WriteLine("6. View full list of awards.");
				Console.WriteLine("7. Add new reward.");
				Console.WriteLine("8. Remove award.");
				Console.WriteLine("=====================Other=======================");
				Console.WriteLine("S. Save changes.");
				Console.WriteLine("Q. Exit.");
				Console.Write(Environment.NewLine + "Input: ");
				switch (Console.ReadKey().Key)
				{
					case ConsoleKey.D1:
						Console.WriteLine();
						ShowAllUsers();
						break;
					case ConsoleKey.D2:
						Console.WriteLine();
						AddNewUser();
						break;
					case ConsoleKey.D3:
						Console.WriteLine();
						AddUserAward();
						break;
					case ConsoleKey.D4:
						Console.WriteLine();
						RemoveUserAward();
						break;
					case ConsoleKey.D5:
						Console.WriteLine();
						DeleteUser();
						break;
					case ConsoleKey.D6:
						Console.WriteLine();
						ShowAllAwards();
						break;
					case ConsoleKey.D7:
						Console.WriteLine();
						AddNewAward();
						break;
					case ConsoleKey.D8:
						Console.WriteLine();
						DeleteAward();
						break;
					case ConsoleKey.S:
						Console.WriteLine();
						SaveAll();
						break;
					case ConsoleKey.Q:
						Environment.Exit(0);
						break;
					default:
						Console.WriteLine("Incorrect data entered.");
						break;
				}
			}
		}

		private static void DeleteAward()
		{
			Console.Write("Enter award id: ");
			string id = Console.ReadLine();
			Guid guid = new Guid(id);
			try
			{
				bLL.RemoveAward(guid);
				Console.WriteLine("Award was successfuly deleted.");
			}
			catch (ArgumentOutOfRangeException e)
			{
				Console.WriteLine(e.Message);
			}

		}

		private static void AddNewAward()
		{
			Console.Write("Enter name of award: ");
			string name = Console.ReadLine();
			Award award = new Award(name);
			bLL.AddNewAward(award);
			Console.WriteLine("Award was added.");
		}

		private static void ShowAllAwards()
		{
			Award[] awards = bLL.GetAllAwards();
			foreach (Award x in awards)
			{
				Console.WriteLine();
				Console.WriteLine("=========AWARD=========");
				Console.WriteLine($"ID: {x.id}, Name: {x.Name}");
				if (x.GetOwners().Count != 0)
				{
					Console.WriteLine("Owners: ");
					foreach (Guid id in x.GetOwners())
					{
						Console.WriteLine($"ID: {id}");
					}
				}
				Console.WriteLine("=======================");
				Console.WriteLine();
			}
			Console.WriteLine();
		}

		/// <summary>
		/// Save all users
		/// </summary>
		private static void SaveAll()
		{
			bLL.SaveAll();
		}

		private static void DeleteUser()
		{
			Console.Write("Enter user ID: ");
			string id = Console.ReadLine();

			Guid guid = new Guid(id);
			try
			{
				bLL.RemoveUser(guid);
				Console.WriteLine("User was successfuly deleted.");
			}
			catch (ArgumentOutOfRangeException e)
			{
				Console.WriteLine(e.Message);
			}


		}
		/// <summary>
		/// Remove user award
		/// </summary>
		private static void RemoveUserAward()
		{
			Console.Write("Enter user ID: ");
			Guid userId = new Guid(Console.ReadLine());
			Console.Write("Enter award ID: ");
			Guid awardId = new Guid(Console.ReadLine());
			try
			{
				bLL.RemoveAwardFromUser(userId, awardId);
			}
			catch (ArgumentOutOfRangeException e)
			{
				Console.WriteLine(e.Message);
			}
		}
		/// <summary>
		/// Add award to user
		/// </summary>
		private static void AddUserAward()
		{
			Console.Write("Enter user ID: ");
			Guid userId = new Guid(Console.ReadLine());
			Console.Write("Enter award ID: ");
			Guid awardId = new Guid(Console.ReadLine());
			try
			{
				bLL.AddAwardToUser(userId, awardId);
			}
			catch (ArgumentException e)
			{
				Console.WriteLine(e.Message);
			}
		}
		/// <summary>
		/// Add new user
		/// </summary>
		private static void AddNewUser()
		{
			Console.Write("Enter name of user: ");
			string name = Console.ReadLine();
			Console.Write("Enter birthdate of user: ");
			string birthdate = Console.ReadLine();
			if (!DateTime.TryParse(birthdate, out DateTime bday))
			{
				Console.WriteLine("Date entered incorrectly.");
				return;
			}
			User user = new User(name, bday);
			bLL.AddNewUser(user);
			Console.WriteLine("User was added.");
		}

		/// <summary>
		/// Print all users to console
		/// </summary>
		private static void ShowAllUsers()
		{
			User[] users = bLL.GetAllUsers();
			foreach (User x in users)
			{
				Console.WriteLine();
				Console.WriteLine("===========USER===========");
				Console.WriteLine($"ID: {x.id}, Name: {x.Name}, Birthdate: {x.DateOfBirth.ToString()}.");
				if (x.GetAwards().Count != 0)
				{
					Console.WriteLine("Awards: ");
					foreach (Guid id in x.GetAwards())
					{
						Console.WriteLine($"ID: {id}");
					}
				}
				Console.WriteLine("==========================");
				Console.WriteLine();
			}
			Console.WriteLine();
		}

	}
}
