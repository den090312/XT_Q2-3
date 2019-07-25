using System;
using System.Collections.Generic;

namespace Task1_Part2
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.Write("Task 1.11. Enter the string s: ");
			string s = Console.ReadLine();
			Console.WriteLine("Average word length per line s: {0}", AverrageStringLength(s));
			Console.Write("Task 1.12. Enter the string s1: ");
			string s1 = Console.ReadLine();
			Console.Write("Enter the string s2: ");
			string s2 = Console.ReadLine();
			CharDoubler(ref s1, s2);
			Console.WriteLine("New line: {0}", s1);
		}

		/// <summary>
		/// Calculates the average word length per line.
		/// </summary>
		/// <param name="s">String for calculations</param>
		/// <returns>Average word length per line</returns>
		static int AverrageStringLength(string s) =>
			AverrageOfArray(WordsLength(s));

		/// <summary>
		/// Returns the length of words in a string.
		/// </summary>
		/// <param name="s">String for calculations</param>
		/// <returns>Line lengths</returns>
		static List<int> WordsLength(string s)
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
		/// Finds the arithmetic average of numbers in the List
		/// </summary>
		/// <param name="intList">A set of integers</param>
		/// <returns>Average</returns>
		static int AverrageOfArray(List<int> intList)
		{
			int sum = 0;
			foreach (int x in intList)
			{
				sum += x;
			}
			return (intList.Count != 0) ? sum / intList.Count : 0;
		}
		/// <summary>
		/// Doubles the characters in the first line that appear in the second
		/// </summary>
		/// <param name="firstString"></param>
		/// <param name="secondString"></param>
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
