using System;

namespace Task0
{
	class Program
	{
		static void Main(string[] args)
		{
			/************Задание №1************/
			Console.Write("№1. Введите положительное целое число N: ");
			if (uint.TryParse(Console.ReadLine(), out uint N))
			{
				if (N == 0)
				{
					Console.Write("Неверно введены данные.");
					return;
				}
				else
				{
					Console.WriteLine("Полученная строка: {0}", Sequence(N));
				}
			}
			else
			{
				Console.Write("Неверно введены данные.");
				return;
			}
			/************Задание №2************/
			Console.Write("№2. Введите положительное целое число M: ");
			if (uint.TryParse(Console.ReadLine(), out uint M))
			{
				if (N == 0)
				{
					Console.Write("Неверно введены данные.");
					return;
				}
				else
				{
					if (Simple(M))
						Console.WriteLine("Число M простое.");
					else
						Console.WriteLine("Число M не простое.");
				}
			}
			else
			{
				Console.Write("Неверно введены данные.");
				return;
			}
			/************Задание №3************/
			Console.Write("№3. Введите положительное нечётное целое число L: ");
			if (uint.TryParse(Console.ReadLine(), out uint L))
			{
				if (N == 0 || L % 2 == 0)
				{
					Console.Write("Неверно введены данные.");
					return;
				}
				else
				{
					Square(L);
				}
			}
			else
			{
				Console.Write("Неверно введены данные.");
				return;
			}
		}
		/// <summary>
		/// Формирует и возвращает строку вида 1, 2, 3, … N (положительное число).
		/// </summary>
		/// <param name="N">Положительное число.</param>
		/// <returns>Строка вида 1, 2, 3, … N (положительное число).</returns>
		static string Sequence(uint N)
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
		/// Определяет, является ли заданное число N (положительное целое) простым.
		/// </summary>
		/// <param name="N">Положительное число.</param>
		/// <returns>bool - является ли число простым.</returns>
		static bool Simple(uint N)
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
		/// Выводит на экран квадрат из звёздочек со стороной равной N (положительное нечётное целое число).
		/// </summary>
		/// <param name="N">Положительное нечётное целое число</param>
		static void Square(uint N)
		{
			uint center = N / 2 + 1;
			for (int i = 1; i <= N; i++)
			{
				for (int j = 1; j <= N; j++)
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
