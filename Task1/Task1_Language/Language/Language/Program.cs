using System;

namespace Language
{

	public static class ArrayOperations
	{
		private static void QuickSort(int[] array, int left, int right)
		{
			int i = left; //left element 
			int j = right; //right element
			int piv = array[(i + j) / 2]; //member element
										  //we start the passage and to the left and to the right of the member element
			while (i <= j)
			{
				while (array[i] < piv)
					i++;
				while (array[j] > piv)
					j--;
				if (i <= j)
				{
					int buf = array[i];
					array[i] = array[j];
					array[j] = buf;
					i++;
					j--;
				}
			}
			if (left < j)
				QuickSort(array, left, j); //call the sort recursively for the left and right subarrays,
			if (i < right)                 //while they have at least 2 elements 
				QuickSort(array, i, right);
		}
		/// <summary>
		/// Sorts the integer array in ascending order.
		/// </summary>
		/// <param name="array">Sort array</param>
		public static void Sort(int[] array)
		{
			QuickSort(array, 0, array.Length - 1);
		}
		/// <summary>
		/// Creates an array with random numbers.
		/// </summary>
		/// <param name="n">Number of array elements</param>
		/// <param name="maxValue">A number that does not exceed the elements of the array</param>
		/// <returns>Generated array</returns>
		public static int[] GenerateArray(int n, int maxValue)
		{
			var array = new int[n];
			Random random = new Random();
			for (int i = 0; i < n; i++)
			{
				array[i] = random.Next(-maxValue, maxValue);
			}
			return array;
		}
		/// <summary>
		/// Creates a two-dimensional array with random numbers.
		/// </summary>
		/// <param name="n">First dimension</param>
		/// <param name="m">Second dimension</param>
		/// <param name="maxValue">Maximum value</param>
		/// <returns>Generated array</returns>
		public static int[,] GenerateArray(int n, int m, int maxValue)
		{
			var array = new int[n, m];
			Random random = new Random();
			for (int i = 0; i < n; i++)
			{
				for (int j = 0; j < m; j++)
				{
					array[i, j] = random.Next(-maxValue, maxValue);
				}
			}
			return array;
		}
		/// <summary>
		/// Creates a three-dimensional array with random numbers.
		/// </summary>
		/// <param name="n">First dimension</param>
		/// <param name="m">Second dimension</param>
		/// <param name="l">Third dimension</param>
		/// <param name="maxValue">Maximum value</param>
		/// <returns>Generated array</returns>
		public static int[,,] GenerateArray(int n, int m, int l, int maxValue)
		{
			var array = new int[n, m, l];
			Random random = new Random();
			for (int i = 0; i < n; i++)
			{
				for (int j = 0; j < m; j++)
				{
					for (int k = 0; k < l; k++)
					{
						array[i, j, k] = random.Next(-maxValue, maxValue);
					}
				}
			}
			return array;
		}
		/// <summary>
		/// Output array to console
		/// </summary>
		/// <param name="array">Output array</param>
		public static void PrintArray(int[] array)
		{
			foreach (int x in array)
			{
				Console.Write(x.ToString() + " ");
			}
			Console.WriteLine();
		}
		/// <summary>
		/// Prints a two-dimensional array to the console.
		/// </summary>
		/// <param name="array">Output array</param>
		public static void PrintArray(int[,] array, int n, int m)
		{
			for (int i = 0; i < n; i++)
			{
				for (int j = 0; j < m; j++)
				{
					Console.Write(array[i, j].ToString() + " ");
				}
				Console.WriteLine();
			}
		}
		/// <summary>
		/// Prints a three-dimensional array to the console.
		/// </summary>
		/// <param name="array">Output array</param>
		public static void PrintArray(int[,,] array)
		{
			foreach (int x in array)
			{
				Console.Write(x.ToString() + " ");
			}
			Console.WriteLine();
		}
		/// <summary>
		/// Finds the maximum value in the array
		/// </summary>
		/// <param name="array">Search array</param>
		/// <returns>The maximum value in the array</returns>
		public static int MaxValue(int[] array)
		{
			int max = array[0];
			for (int i = 1; i < array.Length; i++)
			{
				if (array[i] > max)
					max = array[i];
			}
			return max;
		}
		/// <summary>
		/// Finds the minimum value in the array
		/// </summary>
		/// <param name="array">Search array</param>
		/// <returns>Minimum array element</returns>
		public static int MinValue(int[] array)
		{
			int min = array[0];
			for (int i = 1; i < array.Length; i++)
			{
				if (array[i] < min)
					min = array[i];
			}
			return min;
		}
		/// <summary>
		/// Returns the sum of non-negative elements in an array.
		/// </summary>
		/// <param name="array">Search array</param>
		/// <returns>The sum of non-negative elements in the array</returns>
		public static int NonNegativeSum(int[] array)
		{
			int sum = 0;
			foreach (int x in array)
			{
				if (x > 0)
				{
					sum += x;
				}
			}
			return sum;
		}
		/// <summary>
		/// Returns the sum of elements at even places in a two-dimensional array.
		/// </summary>
		/// <param name="array">Search array</param>
		/// <param name="n">The first dimension of the array</param>
		/// <param name="m">The second dimension of the array</param>
		/// <returns>The sum of elements standing in even places in a two-dimensional array</returns>
		public static int Sum2D(int[,] array, int n, int m)
		{
			int sum = 0;
			for (int i = 0; i < n; i++)
			{
				for (int j = 0; j < m; j++)
				{
					if ((i + j) % 2 == 0)
					{
						sum += array[i, j];
					}
				}
			}
			return sum;
		}
		/// <summary>
		/// Replaces all positive numbers with zeros in a three-dimensional array.
		/// </summary>
		/// <param name="array">Array</param>
		/// <param name="n">First dimension</param>
		/// <param name="m">Second dimension</param>
		/// <param name="l">Third dimension</param>
		public static void NoPositive(int[,,] array, int n, int m, int l)
		{
			for (int i = 0; i < n; i++)
			{
				for (int j = 0; j < m; j++)
				{
					for (int k = 0; k < l; k++)
					{
						if (array[i, j, k] > 0)
						{
							array[i, j, k] = 0;
						}
					}
				}
			}
		}
	}
	class Program
	{
		static void Main(string[] args)
		{
			/*******Tasks 1.7, 1.9*********/
			Console.WriteLine("Tasks 1.7, 1.9");
			Console.Write("Enter number n: ");
			if (!int.TryParse(Console.ReadLine(), out int n) && n > 0)
			{
				Console.WriteLine(".");
				return;
			}
			Console.Write("Enter maximum array limit: ");
			if (!int.TryParse(Console.ReadLine(), out int maxValue))
			{
				Console.WriteLine("Incorrect data entered.");
				return;
			}
			int[] array = ArrayOperations.GenerateArray(n, maxValue);

			Console.WriteLine("Array before sorting: ");
			ArrayOperations.PrintArray(array);

			ArrayOperations.Sort(array);
			Console.WriteLine("Array after sorting: ");
			ArrayOperations.PrintArray(array);

			Console.WriteLine("Maximum value in array: {0}, minimum value in array: {1}", ArrayOperations.MaxValue(array), ArrayOperations.MinValue(array));

			Console.WriteLine("Sum of non-negative elements: {0}", 
				ArrayOperations.NonNegativeSum(array));

			/********Задание 1.10**********/
			Console.WriteLine("Task 1.10");
			Console.Write("Enter the first dimension of the array: ");
			if (!int.TryParse(Console.ReadLine(), out int n1) && n1 > 0)
			{
				Console.WriteLine("Incorrect data entered.");
				return;
			}
			Console.Write("Enter the second dimension of the array: ");
			if (!int.TryParse(Console.ReadLine(), out int m1) && m1 > 0)
			{
				Console.WriteLine("Incorrect data entered.");
				return;
			}
			Console.Write("Enter maximum array limit: ");
			if (!int.TryParse(Console.ReadLine(), out int maxValue1))
			{
				Console.WriteLine("Incorrect data entered.");
				return;
			}

			int[,] array2D = ArrayOperations.GenerateArray(n1, m1, maxValue1);
			Console.WriteLine("Received array: ");
			ArrayOperations.PrintArray(array2D, n1, m1);
			Console.WriteLine("The sum of the elements standing in even positions: {0}",
				ArrayOperations.Sum2D(array2D, n1, m1));

			/********Задание 1.8**********/
			Console.WriteLine("Task 1.8");
			Console.Write("Enter the first dimension of the array: ");
			if (!int.TryParse(Console.ReadLine(), out int n2) && n2 > 0)
			{
				Console.WriteLine("Incorrect data entered.");
				return;
			}
			Console.Write("Enter the second dimension of the array: ");
			if (!int.TryParse(Console.ReadLine(), out int m2) && m2 > 0)
			{
				Console.WriteLine("Incorrect data entered.");
				return;
			}
			Console.Write("Enter the third dimension of the array: ");
			if (!int.TryParse(Console.ReadLine(), out int k2) && k2 > 0)
			{
				Console.WriteLine("Incorrect data entered.");
				return;
			}
			Console.Write("Enter maximum array limit: ");
			if (!int.TryParse(Console.ReadLine(), out int maxValue2))
			{
				Console.WriteLine("Incorrect data entered.");
				return;
			}
		
			int[,,] array3D = ArrayOperations.GenerateArray(n2, m2, k2, maxValue2);
			Console.WriteLine("Array before changes: ");
			ArrayOperations.PrintArray(array3D);
			ArrayOperations.NoPositive(array3D, n2, m2, k2);
			Console.WriteLine("Array after changes: ");
			ArrayOperations.PrintArray(array3D);
		}
	}
}
