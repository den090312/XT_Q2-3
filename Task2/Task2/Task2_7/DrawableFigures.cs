using System;
using Task2_1;
using Task2_6;
using Figure;

namespace Task2_7
{
	/// <summary>
	/// Линия
	/// </summary>
	class DrawableLine : Line, IDrawable
	{
		public void Draw()
		{
			Console.WriteLine("Линия от [{0}, {1}] до [{2}, {3}]", StartPoint.X, StartPoint.Y, EndPoint.X, EndPoint.Y);
		}
		public DrawableLine(double X1, double Y1, double X2, double Y2) : base(X1, Y1, X2, Y2)
		{

		}
	}
	/// <summary>
	/// Круг
	/// </summary>
	class DrawableRound : Round, IDrawable
	{
		public void Draw()
		{
			Console.WriteLine("Круг с центром в точке [{0}, {1}] и радиусом {2}", Center.X, Center.Y, Radius);
		}

		public DrawableRound(double Radius, double X, double Y) : base (Radius, X, Y)
		{

		}
	}
	/// <summary>
	/// Кольцо
	/// </summary>
	class DrawableRing : Ring, IDrawable
	{
		public void Draw()
		{
			Console.WriteLine("Кольцо с центром в точке [{0}, {1}], внутренним радиусом {2} и внешним радиусом {3}", Center.X, Center.Y, InnerRadius, OuterRadius);
		}

		public DrawableRing(double X, double Y, double OuterRadius, double InnerRadius) : base(new Point2D(X, Y), OuterRadius, InnerRadius)
		{

		}
	}
	/// <summary>
	/// Окружность
	/// </summary>
	class DrawableCircle : Circle, IDrawable
	{
		public void Draw()
		{
			Console.WriteLine("Окружность с центром в точке [{0}, {1}] и радиусом {2}", Center.X, Center.Y, Radius);
		}

		public DrawableCircle(double X, double Y, double Radius) : base(X, Y, Radius)
		{

		}
	}
	/// <summary>
	/// Прямоугольник
	/// </summary>
	class DrawableRectangle : Rectangle, IDrawable
	{
		public void Draw()
		{
			Console.WriteLine("Прямоугольник, верхний левый угол в точке [{0}, {1}], шириной {2}, высотой {3}", TopPoint.X, TopPoint.Y, Width, Height);
		}

		public DrawableRectangle(double X, double Y, double Width, double Height) : base(X, Y, Width, Height)
		{

		}
	}
}
