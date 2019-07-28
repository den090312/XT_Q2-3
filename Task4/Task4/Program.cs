using System;
using System.Threading;

namespace Task4
{
	class CustomArraySorter<T>
	{
		/// <summary>
		/// Event triggered upon completion of sorting
		/// </summary>
		public event Action<T[]> OnSortComplete;
		/// <summary>
		/// Sorts an array using the compare function.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="array">Array to sort</param>
		/// <param name="comparer">Should return something greater than 0 if t1 > t2, less than 0 if t1 < t2 and zero if they equals</param>
		public void CustomSort(T[] array, Func<T, T, int> comparer)
		{
			QuickSort(array, comparer, 0, array.Length - 1);
			OnSortComplete?.Invoke(array);
		}
		/// <summary>
		/// Async sorts an array using the compare function.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="array">Array to sort</param>
		/// <param name="comparer">Should return something greater than 0 if t1 > t2, less than 0 if t1 < t2 and zero if they equals</param>
		public void CustomSortAsync(T[] array, Func<T, T, int> comparer)
		{
			Thread t = new Thread(() => CustomSort(array, comparer));
			t.Start();
		}
		/// <summary>
		/// Quick sort algorithm
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="array">Array to sort</param>
		/// <param name="comparer">Should return something greater than 0 if t1 > t2, less than 0 if t1 < t2 and zero if they equals</param>
		/// <param name="left">Left border</param>
		/// <param name="right">Right border</param>
		private void QuickSort(T[] array, Func<T, T, int> comparer, int left, int right)
		{
			int i = left; //left element 
			int j = right; //right element 
			T piv = array[(i + j) / 2]; //reference element
										//start the passage and left and right to the reference element
			while (i <= j)
			{
				while (comparer(array[i], piv) < 0)
					i++;
				while (comparer(array[j], piv) > 0)
					j--;
				if (i <= j)
				{
					T buf = array[i];
					array[i] = array[j];
					array[j] = buf;
					i++;
					j--;
				}
			}
			if (left < j)
				QuickSort(array, comparer, left, j); // call recursive sorting for the left and right subarrays,
			if (i < right)                           // while they have at least 2 elements
				QuickSort(array, comparer, i, right);
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("*************STRING ARRAY SORTER*************");
			Console.WriteLine("Enter an array of strings separated by a space: ");
			string[] sArray = Console.ReadLine().Split(' ');
			CustomArraySorter<string> sorter = new CustomArraySorter<string>();
			sorter.OnSortComplete += OnSortCompleteHandler;
			sorter.CustomSortAsync(sArray, StringComparer);
		}

		static void OnSortCompleteHandler(string[] array)
		{
			Console.WriteLine("Sort completed. Final array: ");
			foreach (string item in array)
			{
				Console.WriteLine(item);
			}
		}

		static int StringComparer(string s1, string s2)
		{
			//if strings have various length
			if (s1.Length != s2.Length)
				return (s1.Length > s2.Length) ? 1 : -1;

			//if strings have equals length
			for (int i = 0; i < s1.Length; i++)
			{
				if (s1[i] > s2[i])
					return 1;
				else if (s1[i] < s2[i])
					return -1;
			}

			//if strings are equals	
			return 0;
		}
	}
}
