using System;

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
			Console.WriteLine("Task №1.1");
			Console.Write("Enter a positive integer a: ");
			if (!int.TryParse(Console.ReadLine(), out int a) || a <= 0)
			{
				Console.WriteLine("Incorrect data entered.");
			}
			else
			{
				Console.Write("Enter a positive integer b: ");
				if (!int.TryParse(Console.ReadLine(), out int b) || b <= 0)
					Console.WriteLine("Incorrect data entered.");
				else
					Console.WriteLine("The area of the rectangle with the sides {0} and {1}: {2}", a, b, RectangleArea(a, b));
			}

			Console.WriteLine("Task №1.2");
			Console.Write("Enter a positive integer N: ");
			if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0)
			{
				Console.WriteLine("Incorrect data entered.");
			}
			else
			{
				PrintTriangle(n);
			}

			Console.WriteLine("Task №1.3");
			Console.Write("Enter a positive integer N: ");
			if (!int.TryParse(Console.ReadLine(), out int N) || N <= 0)
			{
				Console.WriteLine("Incorrect data entered.");
			}
			else
			{
				PrintBigTriangle(N);
			}

			Console.WriteLine("Task №1.4");
			Console.Write("Enter a positive integer N: ");
			if (!int.TryParse(Console.ReadLine(), out int T) || N <= 0)
			{
				Console.WriteLine("Incorrect data entered.");
			}
			else
			{
				XmasTree(T);
			}

			Console.WriteLine("Task №1.5");
			Console.WriteLine("The sum of all numbers is less than 1000, a multiple of 3 or 5: {0}", SumOfNumbers(1000));

			Console.WriteLine("Task №1.6. To exit, press Escape.");

			FontAdjustment fontAdjustment = 0;

			while (true)
			{
				Console.Write("Inscription parameters: ");
				if (fontAdjustment == FontAdjustment.Null) Console.Write("null");
				if (fontAdjustment.HasFlag(FontAdjustment.bold))
					Console.Write("Bold ");
				if (fontAdjustment.HasFlag(FontAdjustment.italic))
					Console.Write("Italic ");
				if (fontAdjustment.HasFlag(FontAdjustment.underline))
					Console.Write("Underline ");
				Console.WriteLine("\nEnter:" +
										  "\n       1: bold" +
										  "\n       2: italic" +
										  "\n       3: underline");
				Console.Write("Input: ");
				if (!int.TryParse(Console.ReadLine(), out int input))
				{
					Console.Write("Incorrect data entered.");
					return;
				}
				else if (input > 0 && input < 4)
				{
					if (input == 3)
						input++;
					FontAdjustment inputFlag = (FontAdjustment)input;
					if (fontAdjustment.HasFlag(inputFlag))
						fontAdjustment ^= inputFlag;
					else
						fontAdjustment |= inputFlag;
				}
			}
		}
		/// <summary>
		/// Considers the area of the rectangle with the sides a и b
		/// </summary>
		/// <param name="a">Positive integer</param>
		/// <param name="b">Positive integer</param>
		/// <returns>Area of the rectangle</returns>
		static int RectangleArea(int a, int b)
		{
			return a * b;
		}
		/// <summary>
		/// Displays N lines with 1 to N characters *
		/// </summary>
		/// <param name="N">Positive integer</param>
		static void PrintTriangle(int N)
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
		/// Displays a triangle of N lines
		/// </summary>
		/// <param name="N">Number of lines</param>
		static void PrintBigTriangle(int N)
		{
			PrintTriangleWithIndent(N, N - 1);
		}
		/// <summary>
		/// Prints N triangles to console
		/// </summary>
		/// <param name="N">Number of triangles</param>
		static void XmasTree(int N)
		{
			for (int i = 1; i <= N; i++)
			{
				PrintTriangleWithIndent(i, N - 1);
			}
		}
		/// <summary>
		/// Displays an indented triangle in front of it
		/// </summary>
		/// <param name="N">The number of rows of the triangle</param>
		/// <param name="triangleSpace">Indent before triangle</param>
		private static void PrintTriangleWithIndent(int N, int triangleSpace)
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
		/// Counts the sum of all numbers less than N, multiples of 3 or 5.
		/// </summary>
		/// <param name="N">Maximum number</param>
		/// <returns>The sum of all numbers is less than N, multiples of 3 or 5</returns>
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
