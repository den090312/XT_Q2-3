using System;
using System.Collections.Generic;

namespace Task1_Part2
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.Write("Задание 1.11. Введите строку s: ");
			string s = Console.ReadLine();
			Console.WriteLine("Средняя длина слов в строке s: {0}", AverrageStringLength(s));
			Console.Write("Задание 1.12. Введите строку s1: ");
			string s1 = Console.ReadLine();
			Console.Write("Введите строку s2: ");
			string s2 = Console.ReadLine();
			CharDoubler(ref s1, s2);
			Console.WriteLine("Новая строка: {0}", s1);
		}

		/// <summary>
		/// Вычисляет среднюю длину слов в строке
		/// </summary>
		/// <param name="s">Строка для вычислений</param>
		/// <returns>Средняя длина слов в строке</returns>
		static int AverrageStringLength(string s) =>
			AverrageOfArray(wordsLength(s));

		/// <summary>
		/// Возвращает длины слов в строке
		/// </summary>
		/// <param name="s">Строка для вычислений</param>
		/// <returns>Длины слов в строке</returns>
		static List<int> wordsLength(string s)
		{
			var buff = new List<int>();
			int index = 0;
			while (index < s.Length)
			{
				int wordLength = 0;
				while (index < s.Length && char.IsLetter(s[index]))
				{
					wordLength++;
					index++;
				}
				if (wordLength != 0)
					buff.Add(wordLength);
				index++;
			}
			return buff;
		}

		/// <summary>
		/// Находит среднее арифметическое чисел в List
		/// </summary>
		/// <param name="intList">Набор целых чисел</param>
		/// <returns>Среднее арифметическое</returns>
		static int AverrageOfArray(List<int> intList)
		{
			int sum = 0;
			foreach (int x in intList)
			{
				sum += x;
			}
			return (intList.Count != 0) ? sum / intList.Count : 0;
		}

		static void CharDoubler(ref string firstString, string secondString)
		{
			for (int i = 0; i < firstString.Length; i++)
			{
				if (secondString.Contains(firstString[i]))
				{
					string str = firstString[i].ToString() + firstString[i];
					firstString = firstString.Remove(i, 1).Insert(i, str);
					i++;
				}
			}
		}
	}
}
