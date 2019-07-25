using System;

namespace Task0
{
	class Program
	{
		static void Main(string[] args)
		{
			/************Task №1************/
			Console.Write("№1. Enter a positive integer N: ");
			if (uint.TryParse(Console.ReadLine(), out uint N))
			{
				if (N == 0)
				{
					Console.Write("Incorrect data entered.");
					return;
				}
				else
				{
					Console.WriteLine("Received string: {0}", GenerateSequence(N));
				}
			}
			else
			{
				Console.Write("Incorrect data entered.");
				return;
			}
			/************Задание №2************/
			Console.Write("№2. Enter a positive integer M: ");
			if (uint.TryParse(Console.ReadLine(), out uint M))
			{
				if (N == 0)
				{
					Console.Write("Incorrect data entered.");
					return;
				}
				else
				{
					if (IsSimple(M))
						Console.WriteLine("M number is simple.");
					else
						Console.WriteLine("M number isn't simple.");
				}
			}
			else
			{
				Console.Write("Incorrect data entered.");
				return;
			}
			/************Task №3************/
			Console.Write("№3. Enter a positive not simple integer L: ");
			if (uint.TryParse(Console.ReadLine(), out uint L))
			{
				if (N == 0 || L % 2 == 0)
				{
					Console.Write("Incorrect data entered.");
					return;
				}
				else
				{
					PrintSquare(L);
				}
			}
			else
			{
				Console.Write("Incorrect data entered.");
				return;
			}
		}
		/// <summary>
		/// Generates and returns a string of the form 1, 2, 3, … N (positive integer).
		/// </summary>
		/// <param name="N">Positive integer.</param>
		/// <returns>String of the form 1, 2, 3, … N (positive integer).</returns>
		static string GenerateSequence(uint N)
		{
			string result = string.Empty;
			for (int i = 1; i <= N; i++)
			{
				result += i;
				if (i <= N - 1)
				{
					result += ", ";
				}
			}
			return result;
		}
		/// <summary>
		/// Determines whether the given number N (positive integer) is simple.
		/// </summary>
		/// <param name="N">Positive integer.</param>
		/// <returns>bool - is the number simple.</returns>
		static bool IsSimple(uint N)
		{
			for (int i = 2; i <= Convert.ToInt32(Math.Sqrt(N)); i++)
			{
				if (N % i == 0)
				{
					return false;
				}
			}
			return true;
		}
		/// <summary>
		/// Displays a square of stars with a side equal to N (positive odd integer).
		/// </summary>
		/// <param name="N">Positive odd integer</param>
		static void PrintSquare(uint N)
		{
			uint center = N / 2;
			for (int i = 0; i < N; i++)
			{
				for (int j = 0; j < N; j++)
				{
					if (i != center || j != center)
					{
						Console.Write("* ");
					}
					else
					{
						Console.Write("  ");
					}
				}
				Console.WriteLine();
			}
		}
	}
}
