using System;
using System.Collections.Generic;

namespace Task1_Part1
{
	[Flags]
	public enum FontAdjustment
	{
		Null = 0,
		bold = 1,
		italic = 2,
		underline = 4
	}

	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Задание №1.1");
			Console.Write("Введите положительное число a: ");
			if (!int.TryParse(Console.ReadLine(), out int a) || a <= 0)
			{
				Console.WriteLine("Неверно введены данные.");
			}
			else
			{
				Console.Write("Введите положительное число b: ");
				if (!int.TryParse(Console.ReadLine(), out int b) || b <= 0)
					Console.WriteLine("Неверно введены данные.");
				else
					Console.WriteLine("Площадь прямоугольника со сторонами {0} и {1}: {2}", a, b, Rectangle(a, b));
			}

			Console.WriteLine("Задание №1.2");
			Console.Write("Введите положительное число N: ");
			if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0)
			{
				Console.WriteLine("Неверно введены данные.");
			}
			else
			{
				Triangle(n);
			}

			Console.WriteLine("Задание №1.3");
			Console.Write("Введите положительное число N: ");
			if (!int.TryParse(Console.ReadLine(), out int N) || N <= 0)
			{
				Console.WriteLine("Неверно введены данные.");
			}
			else
			{
				AnotherTriangle(N);
			}

			Console.WriteLine("Задание №1.4");
			Console.Write("Введите положительное число N: ");
			if (!int.TryParse(Console.ReadLine(), out int T) || N <= 0)
			{
				Console.WriteLine("Неверно введены данные.");
			}
			else
			{
				XmasTree(T);
			}

			Console.WriteLine("Задание №1.5");
			Console.WriteLine("Сумма всех чисел меньше 1000, кратных 3 или 5: {0}", SumOfNumbers(1000));

			Console.WriteLine("Задание №1.6. Для выхода нажмите Escape.");

			FontAdjustment fontAdjustment = 0;

			while (true)
			{
				Console.Write("Параметры надписи: ");
				if (fontAdjustment == FontAdjustment.Null) Console.Write("null");
				if (fontAdjustment.HasFlag(FontAdjustment.bold))
					Console.Write("Bold ");
				if (fontAdjustment.HasFlag(FontAdjustment.italic))
					Console.Write("Italic ");
				if (fontAdjustment.HasFlag(FontAdjustment.underline))
					Console.Write("Underline ");
				Console.WriteLine("\nВведите:" +
										  "\n       1: bold" +
										  "\n       2: italic" +
										  "\n       3: underline");
				switch (Console.ReadKey().Key)
				{
					case ConsoleKey.D1:
						if (fontAdjustment.HasFlag(FontAdjustment.bold))
							fontAdjustment ^= FontAdjustment.bold;
						else
							fontAdjustment |= FontAdjustment.bold;
						break;
					case ConsoleKey.D2:
						if (fontAdjustment.HasFlag(FontAdjustment.italic))
							fontAdjustment ^= FontAdjustment.italic;
						else
							fontAdjustment |= FontAdjustment.italic;
						break;
					case ConsoleKey.D3:
						if (fontAdjustment.HasFlag(FontAdjustment.underline))
							fontAdjustment ^= FontAdjustment.underline;
						else
							fontAdjustment |= FontAdjustment.underline;
						break;
				}
				if (Console.ReadKey(true).Key == ConsoleKey.Escape)
				{
					break;
				}
			}
		}
			/// <summary>
			/// Считает площадь прямоугольника со сторонами a и b
			/// </summary>
			/// <param name="a">Положительное целое число</param>
			/// <param name="b">Положительное целое число</param>
			/// <returns>Площадь прямоугольника</returns>
			static int Rectangle(int a, int b)
			{
				return a * b;
			}
			/// <summary>
			/// Выводит на экран N строк с от 1 до N символами *
			/// </summary>
			/// <param name="N">Положительное целое число</param>
			static void Triangle(int N)
			{
				for (int i = 1; i <= N; i++)
				{
					for (int j = 1; j <= i; j++)
					{
						Console.Write('*');
					}
					Console.WriteLine();
				}
			}
			/// <summary>
			/// Выводит треугольник из N строк
			/// </summary>
			/// <param name="N">Количество строк</param>
			static void AnotherTriangle(int N)
			{
				PrintTriangle(N, N - 1);
			}
			/// <summary>
			/// Выводит N треугольников в консоль
			/// </summary>
			/// <param name="N">Количество треугольников</param>
			static void XmasTree(int N)
			{
				for (int i = 1; i <= N; i++)
				{
					PrintTriangle(i, N - 1);
				}
			}
			/// <summary>
			/// Выводит треугольник с отступом перед ним в консоль 
			/// </summary>
			/// <param name="N">Количество строк треугольника</param>
			/// <param name="triangleSpace">Отступ перед треугольником</param>
			private static void PrintTriangle(int N, int triangleSpace)
			{
				int spaceCount = triangleSpace;
				int starsCount = 1;
				for (int i = 0; i < N; i++)
				{
					for (int j = 0; j < spaceCount; j++)
					{
						Console.Write(" ");
					}
					for (int it = 0; it < starsCount; it++)
					{
						Console.Write("*");
					}
					spaceCount--;
					starsCount += 2;
					Console.WriteLine();
				}
			}
			/// <summary>
			/// Считает сумму всех чисел меньше N, кратных 3 или 5.
			/// </summary>
			/// <param name="N">Максимальное число</param>
			/// <returns>Сумма всех чисел меньше N, кратных 3 или 5</returns>
			static int SumOfNumbers(int N)
			{
				int sum = 0;
				for (int i = 3; i < N; i++)
				{
					if (i % 3 == 0 || i % 5 == 0)
					{
						sum += i;
					}
				}
				return sum;
			}

		}
	}
