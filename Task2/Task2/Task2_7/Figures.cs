using System;
using Figure;

namespace Task2_7
{
	public class Line
	{
		public Point2D StartPoint { get; set; }
		public Point2D EndPoint { get; set; }
		public Line(double X1, double Y1, double X2, double Y2)
		{
			StartPoint = new Point2D(X1, Y1);
			EndPoint = new Point2D(X2, Y2);
		}
	}

	public class Circle
	{
		public Point2D Center{ get; set; }

		private double radius;
		public double Radius
		{
			get => radius; 
			set
			{
				if (value >= 0)
					radius = value;
				else throw new ArgumentException("Wrong argument: radius cannot be negative.");
			}
		}

		public Circle(double X, double Y, double Radius)
		{
			Center = new Point2D(X, Y);
			this.Radius = Radius;
		}
	}

	public class Rectangle
	{
		public Point2D TopPoint { get; set; }

		private double height;
		public double Height
		{
			get => height; 
			set
			{
				if (value >= 0)
					height = value;
				else throw new ArgumentException("Wrong argument: height cannot be negative.");
			}
		}

		private double width;
		public double Width
		{
			get => width;
			set
			{
				if (value >= 0)
					width = value;
				else throw new ArgumentException("Wrong argument: height cannot be negative.");
			}
		}

		public Rectangle(double X, double Y, double Height, double Width)
		{
			TopPoint = new Point2D(X, Y);
			this.Height = Height;
			this.Width = Width;
		}
	}
}
