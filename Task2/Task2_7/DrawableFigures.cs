using System;
using Task2_1;
using Task2_6;
using Figure;

namespace Task2_7
{
	/// <summary>
	/// Line
	/// </summary>
	class DrawableLine : Line, IDrawable
	{
		public void Draw()
		{
			Console.WriteLine("Line from [{0}, {1}] to [{2}, {3}]", StartPoint.X, StartPoint.Y, EndPoint.X, EndPoint.Y);
		}
		public DrawableLine(double X1, double Y1, double X2, double Y2) : base(X1, Y1, X2, Y2)
		{

		}
	}
	/// <summary>
	/// Round
	/// </summary>
	class DrawableRound : Round, IDrawable
	{
		public void Draw()
		{
			Console.WriteLine("Circle centered at [{0}, {1}] and radius {2}", Center.X, Center.Y, Radius);
		}

		public DrawableRound(double Radius, double X, double Y) : base (Radius, X, Y)
		{

		}
	}
	/// <summary>
	/// Ring
	/// </summary>
	class DrawableRing : Ring, IDrawable
	{
		public void Draw()
		{
			Console.WriteLine("Ring with center at [{0}, {1}], inner radius {2} and outer radius {3}", Center.X, Center.Y, InnerRadius, OuterRadius);
		}

		public DrawableRing(double X, double Y, double OuterRadius, double InnerRadius) : base(new Point2D(X, Y), OuterRadius, InnerRadius)
		{

		}
	}
	/// <summary>
	/// Circle
	/// </summary>
	class DrawableCircle : Circle, IDrawable
	{
		public void Draw()
		{
			Console.WriteLine("Circle with center at [{0}, {1}] and radius {2}", Center.X, Center.Y, Radius);
		}

		public DrawableCircle(double X, double Y, double Radius) : base(X, Y, Radius)
		{

		}
	}
	/// <summary>
	/// Rectangle
	/// </summary>
	class DrawableRectangle : Rectangle, IDrawable
	{
		public void Draw()
		{
			Console.WriteLine("Rectangle, upper left corner at point [{0}, {1}], {2} width, {3} height", TopPoint.X, TopPoint.Y, Width, Height);
		}

		public DrawableRectangle(double X, double Y, double Width, double Height) : base(X, Y, Width, Height)
		{

		}
	}
}
