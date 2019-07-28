using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I_SEEK_YOU
{
	

	class Program
	{
		static void Main(string[] args)
		{
			int[] arr1 = { 1, 2, 3, -1, -2, -3 };
			int[] arr2 = { 1, 2, 3, -1, 2, -3 };
			int[] arr3 = { 1, 2, 3, -1, -2, -5 };
			int[] arr4 = { 1, 2, -3, -1, -2, -3 };
			int[] arr5 = { 8, 2, 3, -1, -2, -6 };

			Console.WriteLine("Positive elements in first array by simple finder: ");
			PrintArray(ArraySeeker.FindPositiveElemets(arr1));

			Console.WriteLine("Positive elements in second array by predicate finder: ");
			PrintArray(ArraySeeker.Find(arr2, IsPositiveNumber));

			Console.WriteLine("Positive elements in third array by anonymous method: ");
			Predicate<int> method = delegate (int x)
			{
				return x > 0;
			};
			PrintArray(ArraySeeker.Find(arr2, method));

			Console.WriteLine("Positive elements in fourth array by lambda expression: ");
			PrintArray(ArraySeeker.Find(arr2, (int x) => x > 0));

			Console.WriteLine("Positive elements in fifth array by LINQ: ");
			PrintArray(ArraySeeker.LinqFind(arr2, (int x) => x > 0));
		}

		static bool IsPositiveNumber(int number) => number > 0;

		static void PrintArray<T>(T[] array)
		{
			foreach (T item in array)
			{
				Console.Write(item + " ");
			}
			Console.WriteLine();
		}
	}

	static class ArraySeeker
	{

		/// <summary>
		/// Finds positive elements in array
		/// </summary>
		/// <param name="array"></param>
		/// <returns></returns>
		public static int[] FindPositiveElemets(int[] array)
		{
			List<int> list = new List<int>();
			foreach (int item in array)
			{
				if (item > 0)
				{
					list.Add(item);
				}
			}
			return list.ToArray();
		}

		/// <summary>
		/// Finds elements in the array that match the predicate
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="array"></param>
		/// <param name="predicate"></param>
		/// <returns></returns>

		public static T[] Find<T>(T[] array, Predicate<T> predicate)
		{
			List<T> list = new List<T>();
			foreach (T item in array)
			{
				if (predicate(item))
				{
					list.Add(item);
				}
			}
			return list.ToArray();
		}

		/// <summary>
		/// Finds elements in the array that match the predicate via LINQ
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="array"></param>
		/// <param name="predicate"></param>
		/// <returns></returns>
		public static T[] LinqFind<T>(T[] array, Predicate<T> predicate)
		{
			var newArray = from item in array
						   where predicate(item)
						   select item;
			return newArray.ToArray();
		}
	}
}
