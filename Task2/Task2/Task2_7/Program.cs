namespace Task2_7
{
	class Program
	{
		static void Main(string[] args)
		{
			DrawableCircle circle = new DrawableCircle(0, 0, 3);
			DrawableLine line = new DrawableLine(0, 0, 1, 1);
			DrawableRectangle rectangle = new DrawableRectangle(5, 5, 2, 2);
			DrawableRing ring = new DrawableRing(3, 4, 5, 2);
			DrawableRound round = new DrawableRound(2, 8, 8);
			VectorGraphicsEditor.Draw(circle, line, rectangle, ring, round);
		}
	}

	static class VectorGraphicsEditor
	{
		public static void Draw(IDrawable figure) => figure.Draw();
		public static void Draw(params IDrawable[] figures)
		{
			foreach (IDrawable figure in figures)
			{
				figure.Draw();
			}
		}
	}
}
