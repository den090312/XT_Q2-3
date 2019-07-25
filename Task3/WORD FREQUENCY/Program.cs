using System;
using System.Collections.Generic;

namespace WORD_FREQUENCY
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Enter text:");
			string text = Console.ReadLine();

			Dictionary<string, int> wordsFrequency = WordsFrequncy(text);

			foreach (string word in wordsFrequency.Keys)
			{
				Console.WriteLine("The word \"{0} \" occurs: {1} times", word, wordsFrequency[word]);
			}
		}

		/// <summary>
		/// Calculates the occurrence of words in the text case-insensitive.
		/// </summary>
		/// <param name="text">Search text</param>
		/// <returns>Dictionary, where key is a word in the text, and value is its number in the text.</returns>
		static Dictionary<string, int> WordsFrequncy(string text)
		{
			string[] words = text.Split(new char[] { ' ', '.' }, StringSplitOptions.RemoveEmptyEntries);
			Dictionary<string, int> wordsFrequency = new Dictionary<string, int>();
			foreach (string word in words)
			{
					if (wordsFrequency.ContainsKey(word.ToLower()))
						wordsFrequency[word.ToLower()]++;
					else wordsFrequency.Add(word.ToLower(), 1);
			}
			return wordsFrequency;
		}
	}
}
