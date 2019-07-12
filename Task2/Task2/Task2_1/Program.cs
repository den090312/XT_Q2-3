using System;
using Figure;

namespace Task2_1
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.Write("Введите радиус окружности: ");
			if (!double.TryParse(Console.ReadLine(), out double radius) || radius <= 0)
			{
				Console.WriteLine("Неверно введены данные.");
				return;
			}
			Console.Write("Введите координату центра X: ");
			if (!double.TryParse(Console.ReadLine(), out double x))
			{
				Console.WriteLine("Неверно введены данные.");
				return;
			}
			Console.Write("Введите координату центра Y: ");
			if (!double.TryParse(Console.ReadLine(), out double y))
			{
				Console.WriteLine("Неверно введены данные.");
				return;
			}
			Round round = new Round(radius, x, y);
			Console.Write("Длина описанной окружности: ");
			Console.WriteLine(round.Length);
			Console.Write("Площадь круга: ");
			Console.WriteLine(round.Area);
		}
	}

	public class Round
	{
		private double radius;
		public double Radius
		{
			set
			{
				if (value >= 0)
					radius = value;
				else throw new ArgumentException("Wrong argument: radius cannot be negative.");
			}
			get => radius;
		}

		public Point2D Center { get; set; }

		public Round(double Radius, double X, double Y)
		{
			this.Radius = Radius;
			this.Center = new Point2D(X, Y);
		}
		/// <summary>
		/// Длина описанной окружности
		/// </summary>
		public double Length
		{
			get => 2 * Math.PI * Radius;
		}
		/// <summary>
		/// Площадь круга
		/// </summary>
		public double Area
		{
			get => Math.PI * Radius * Radius;
		}
	}
}
