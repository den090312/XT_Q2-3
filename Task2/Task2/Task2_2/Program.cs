using System;

namespace Task2_2
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.Write("Enter side A: ");
			if (!double.TryParse(Console.ReadLine(), out double A) || A <= 0)
			{
				Console.WriteLine("Incorrect data entered.");
				return;
			}
			Console.Write("Enter side B: ");
			if (!double.TryParse(Console.ReadLine(), out double B) || B <= 0)
			{
				Console.WriteLine("Incorrect data entered.");
				return;
			}
			Console.Write("Enter side C: ");
			if (!double.TryParse(Console.ReadLine(), out double C) || C <= 0)
			{
				Console.WriteLine("Incorrect data entered.");
				return;
			}
			Triangle triangle = new Triangle(A, B, C);
			Console.Write("Perimeter of a triangle: ");
			Console.WriteLine(triangle.Perimeter);
			Console.Write("Perimeter of a triangle: ");
			Console.WriteLine(triangle.Area);
		}
	}

	class Triangle
	{
		private double a;
		private double b;
		private double c;
		public double A
		{
			set
			{
				if (value >= 0)
					a = value;
				else throw new ArgumentException("Wrong argument: side cannot be negative.");
			}
			get => a;
		}
		public double B
		{
			set
			{
				if (value >= 0)
					b = value;
				else throw new ArgumentException("Wrong argument: side cannot be negative.");
			}
			get => b;
		}
		public double C
		{
			set
			{
				if (value >= 0)
					c = value;
				else throw new ArgumentException("Wrong argument: side cannot be negative.");
			}
			get => c;
		}

		public Triangle(double A, double B, double C)
		{
			this.A = A;
			this.B = B;
			this.C = C;
		}

		public double Area
		{
			get
			{
				double p = 0.5 * Perimeter;
				return Math.Sqrt(p * (p - A) * (p - B) * (p - C));
			}
		}

		public double Perimeter
		{
			get => A + B + C;
		}
	}
}
