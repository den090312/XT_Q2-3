using System;
using Figure;

namespace Task2_1
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.Write("Enter the radius of the circle: ");
			if (!double.TryParse(Console.ReadLine(), out double radius) || radius <= 0)
			{
				Console.WriteLine("Incorrect data entered.");
				return;
			}
			Console.Write(" X: ");
			if (!double.TryParse(Console.ReadLine(), out double x))
			{
				Console.WriteLine("Incorrect data entered.");
				return;
			}
			Console.Write("Enter the center coordinate Y: ");
			if (!double.TryParse(Console.ReadLine(), out double y))
			{
				Console.WriteLine("Incorrect data entered.");
				return;
			}
			Round round = new Round(radius, x, y);
			Console.Write("Circumference: ");
			Console.WriteLine(round.Length);
			Console.Write("Area of a circle: ");
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
		/// Circumference
		/// </summary>
		public double Length
		{
			get => 2 * Math.PI * Radius;
		}

		public double Area
		{
			get => Math.PI * Radius * Radius;
		}
	}
}
