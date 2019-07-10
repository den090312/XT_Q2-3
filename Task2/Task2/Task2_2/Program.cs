using System;

namespace Task2_2
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.Write("Введите сторону А: ");
			if (!double.TryParse(Console.ReadLine(), out double A) || A <= 0)
			{
				Console.WriteLine("Неверно введены данные.");
				return;
			}
			Console.Write("Введите сторону B: ");
			if (!double.TryParse(Console.ReadLine(), out double B) || B <= 0)
			{
				Console.WriteLine("Неверно введены данные.");
				return;
			}
			Console.Write("Введите сторону C: ");
			if (!double.TryParse(Console.ReadLine(), out double C) || C <= 0)
			{
				Console.WriteLine("Неверно введены данные.");
				return;
			}
			Triangle triangle = new Triangle(A, B, C);
			Console.Write("Периметр треугольника: ");
			Console.WriteLine(triangle.Perimeter);
			Console.Write("Площадь треугольника: ");
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
		/// <summary>
		/// Площадь треугольника
		/// </summary>
		public double Area
		{
			get
			{
				double p = 0.5 * Perimeter;
				return Math.Sqrt(p * (p - A) * (p - B) * (p - C));
			}
		}
		/// <summary>
		/// Периметр треугольника
		/// </summary>
		public double Perimeter
		{
			get => A + B + C;
		}
	}
}
