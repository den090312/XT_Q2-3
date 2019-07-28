using System;

namespace NUMBER_ARRAY_SUM
{
	class Program
	{
		static void Main(string[] args)
		{
			int[] arr1 = { 1, 2, 3, 4, 5, 6, 7 };
			float[] arr2 = { 1.1f, 2.2f, 3.3f, 4.4f, 5.5f, 6.6f, 7.7f };
			double[] arr3 = { 1.1, 2.2, 3.3, 4.4, 5.5, 6.6 };
			Console.WriteLine("Int array sum: {0}", arr1.Sum());
			Console.WriteLine("Float array sum: {0}", arr2.Sum());
			Console.WriteLine("Double array sum: {0}", arr3.Sum());
		}
	}

	static class NumberArrayExtensions
	{
		public static int Sum(this int[] arr)
		{
			int sum = 0;
			foreach(int item in arr)
			{
				sum += item;
			}
			return sum;
		}

		public static double Sum(this double[] arr)
		{
			double sum = 0;
			foreach (double item in arr)
			{
				sum += item;
			}
			return sum;
		}

		public static float Sum(this float[] arr)
		{
			float sum = 0;
			foreach (float item in arr)
			{
				sum += item;
			}
			return sum;
		}
	}
}
