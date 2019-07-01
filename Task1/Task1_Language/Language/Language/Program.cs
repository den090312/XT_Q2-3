using System;

namespace Language
{

	public static class ArrayOperations
	{
		private static void QuickSort(int[] array, int left, int right)
		{
			int i = left; //левый элемент 
			int j = right; //правый элемент 
			int piv = array[(i + j) / 2]; //опорный элемент 
										  //начинаем проход и слева и справа до опроного элемента 
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
				QuickSort(array, left, j); //вызываем сортировку рекурсивно для левого и правого подмассивов, 
			if (i < right)                 //пока в них есть хотя бы 2 элемента 
				QuickSort(array, i, right);
		}
		/// <summary>
		/// Сортирует целочисленный массив по возрастанию
		/// </summary>
		/// <param name="array">массив для сортировки</param>
		public static void Sort(int[] array)
		{
			QuickSort(array, 0, array.Length - 1);
		}
		/// <summary>
		/// Создёт массив со случайными числами
		/// </summary>
		/// <param name="n">Количество элементов массива</param>
		/// <param name="maxValue">Число, которое не превышают элементы массива</param>
		/// <returns>Сгенерированный массив</returns>
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
		/// Создаёт двумерный массив со случайными числами
		/// </summary>
		/// <param name="n">Первая размерность</param>
		/// <param name="m">Вторая размерность</param>
		/// <param name="maxValue">Максимальное значение</param>
		/// <returns>Сгенерированный массив</returns>
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
		/// Создаёт трёхмерный массив со случайными числами
		/// </summary>
		/// <param name="n">Первая размерность</param>
		/// <param name="m">Вторая размерность</param>
		/// <param name="l">Третья размерность</param>
		/// <param name="maxValue">Максимальное значение</param>
		/// <returns>Сгенерированный массив</returns>
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
		/// Выводит массив в консоль
		/// </summary>
		/// <param name="array">Массив для вывода</param>
		public static void PrintArray(int[] array)
		{
			foreach (int x in array)
			{
				Console.Write(x.ToString() + " ");
			}
			Console.WriteLine();
		}
		/// <summary>
		/// Выводит двумерный массив в консоль
		/// </summary>
		/// <param name="array">Массив для вывода</param>
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
		/// Выводит трёхмерный массив в консоль
		/// </summary>
		/// <param name="array">Массив для вывода</param>
		public static void PrintArray(int[,,] array)
		{
			foreach (int x in array)
			{
				Console.Write(x.ToString() + " ");
			}
			Console.WriteLine();
		}
		/// <summary>
		/// Находит максимальное значение в массиве
		/// </summary>
		/// <param name="array">Массив для поиска</param>
		/// <returns>Максимальное значение в массиве</returns>
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
		/// Находит минимальное значение в массиве
		/// </summary>
		/// <param name="array">Массив для поиска</param>
		/// <returns>Минимальный элемент массива</returns>
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
		/// Возвращает сумму неотрицательных элементов в массиве
		/// </summary>
		/// <param name="array">Массив для поиска</param>
		/// <returns>Сумма неотрицательных элементов в массиве</returns>
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
		/// Возвращает сумму элементов, стоящих на чётных местах в двумерном массиве
		/// </summary>
		/// <param name="array">Массив для поиска</param>
		/// <param name="n">Первая размерность массива</param>
		/// <param name="m">Вторая размерность массива</param>
		/// <returns>Сумма элементов, стоящих на чётных местах в двумерном массиве</returns>
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
		/// Заменяет все положительные числа на нули в трёхмерном массиве
		/// </summary>
		/// <param name="array">Массив</param>
		/// <param name="n">Первая размерность</param>
		/// <param name="m">Вторая размерность</param>
		/// <param name="l">Третья размерность</param>
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
			/*******Задание 1.7, 1.9*********/
			Console.WriteLine("Задание 1.7, 1.9");
			Console.Write("Введите число n: ");
			if (!int.TryParse(Console.ReadLine(), out int n) && n > 0)
			{
				Console.WriteLine("Неверно введены данные.");
				return;
			}
			Console.Write("Введите максимальную границу массива: ");
			if (!int.TryParse(Console.ReadLine(), out int maxValue))
			{
				Console.WriteLine("Неверно введены данные.");
				return;
			}
			int[] array = ArrayOperations.GenerateArray(n, maxValue);

			Console.WriteLine("Массив до сортировки: ");
			ArrayOperations.PrintArray(array);

			ArrayOperations.Sort(array);
			Console.WriteLine("Массив после сортировки: ");
			ArrayOperations.PrintArray(array);

			Console.WriteLine("Максимальное значение в массиве: {0}, минимальное значение в массиве: {1}", ArrayOperations.MaxValue(array), ArrayOperations.MinValue(array));

			Console.WriteLine("Сумма неотрицательных элементов: {0}", 
				ArrayOperations.NonNegativeSum(array));

			/********Задание 1.10**********/
			Console.WriteLine("Задание 1.10");
			Console.Write("Введите первую размерность массива: ");
			if (!int.TryParse(Console.ReadLine(), out int n1) && n1 > 0)
			{
				Console.WriteLine("Неверно введены данные.");
				return;
			}
			Console.Write("Введите вторую размерность массива: ");
			if (!int.TryParse(Console.ReadLine(), out int m1) && m1 > 0)
			{
				Console.WriteLine("Неверно введены данные.");
				return;
			}
			Console.Write("Введите максимальную границу массива: ");
			if (!int.TryParse(Console.ReadLine(), out int maxValue1))
			{
				Console.WriteLine("Неверно введены данные.");
				return;
			}

			int[,] array2D = ArrayOperations.GenerateArray(n1, m1, maxValue1);
			Console.WriteLine("Полученный массив: ");
			ArrayOperations.PrintArray(array2D, n1, m1);
			Console.WriteLine("Сумма элементов, стоящих на чётных позициях: {0}",
				ArrayOperations.Sum2D(array2D, n1, m1));

			/********Задание 1.8**********/
			Console.WriteLine("Задание 1.8");
			Console.Write("Введите первую размерность массива: ");
			if (!int.TryParse(Console.ReadLine(), out int n2) && n2 > 0)
			{
				Console.WriteLine("Неверно введены данные.");
				return;
			}
			Console.Write("Введите вторую размерность массива: ");
			if (!int.TryParse(Console.ReadLine(), out int m2) && m2 > 0)
			{
				Console.WriteLine("Неверно введены данные.");
				return;
			}
			Console.Write("Введите третью размерность массива: ");
			if (!int.TryParse(Console.ReadLine(), out int k2) && k2 > 0)
			{
				Console.WriteLine("Неверно введены данные.");
				return;
			}
			Console.Write("Введите максимальную границу массива: ");
			if (!int.TryParse(Console.ReadLine(), out int maxValue2))
			{
				Console.WriteLine("Неверно введены данные.");
				return;
			}
		
			int[,,] array3D = ArrayOperations.GenerateArray(n2, m2, k2, maxValue2);
			Console.WriteLine("Массив до изменений: ");
			ArrayOperations.PrintArray(array3D);
			ArrayOperations.NoPositive(array3D, n2, m2, k2);
			Console.WriteLine("Массив после изменений: ");
			ArrayOperations.PrintArray(array3D);
		}
	}
}
