using System;
using System.Collections.Generic;

namespace WORD_FREQUENCY
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Введите текст:");
			string text = Console.ReadLine();

			Dictionary<string, int> wordsFrequency = WordsFrequncy(text);

			foreach (string word in wordsFrequency.Keys)
			{
				Console.WriteLine("Слово \"{0}\" встречается: {1} раз", word, wordsFrequency[word]);
			}
		} 

		/// <summary>
		/// Подсчитывает встречаемость слов в тексте без учёта регистра
		/// </summary>
		/// <param name="text">Текст для поиска</param>
		/// <returns>Словарь, где key - слово в тексте, а value - его количество в тексте</returns>
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
