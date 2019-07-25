using System;
using Figure;

namespace Task2_6
{
	class Program
	{
		static void Main(string[] args)
		{
			Point2D point = new Point2D(3, 6);
			int outerRadius = 6;
			int innerRadius = 4;
			Ring ring = new Ring(point, outerRadius, innerRadius);
			Console.WriteLine("Ring, centered on point: [{0}, {1}]", ring.Center.X, ring.Center.Y);
			Console.WriteLine("Radii: {0}, {1}", ring.InnerRadius, ring.OuterRadius);
			Console.WriteLine("Total circumference: {0}", ring.SummaryLength);
			Console.WriteLine("Area: {0}", ring.Area);
		}
	}

	public class Ring
	{
		public Point2D Center { get; set; }

		private double outerRadius;
		public double OuterRadius
		{
			get => outerRadius;
			set
			{
				if (value >= 0)
					outerRadius = value;
				else throw new ArgumentException("Wrong argument: radius cannot be negative");
			}
		}

		private double innerRadius;
		public double InnerRadius
		{
			get => innerRadius;
			set
			{
				if (value < 0)
					throw new ArgumentException("Wrong argument: radius cannot be negative");
				else if (value > outerRadius)
					throw new ArgumentException("Wrong argument: inner radius cannot be bigger then outer radius");
				else
					innerRadius = value;
			}
		}

		public double InnerLength { get => 2 * Math.PI * innerRadius; }
		public double OuterLength { get => 2 * Math.PI * outerRadius; }
		public double SummaryLength { get => InnerLength + OuterLength; }
		public double Area { get => Math.PI * outerRadius * outerRadius - Math.PI * innerRadius * innerRadius; }

		public Ring(Point2D Center, double OuterRadius, double InnerRadius)
		{
			this.Center = Center;
			this.OuterRadius = OuterRadius;
			this.InnerRadius = InnerRadius;
		}
	}
}
