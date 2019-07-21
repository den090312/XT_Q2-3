using System;
using System.Collections.Generic;

namespace LOST
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.Write("Введите количество участников: ");
			if (!int.TryParse(Console.ReadLine(), out int N))
			{
				Console.WriteLine("Неверно введены данные");
				return;
			}
			else
			{
				List<Participant> participantList = new List<Participant>(N);
				GenerateList(participantList, N);
				GenerateProcess(participantList);
			}
		}
		/// <summary>
		/// Заполняет список участников
		/// </summary>
		/// <param name="participantList">Список</param>
		/// <param name="count">Количество участников</param>
		static void GenerateList(List<Participant> participantList, int count)
		{
			for (int i = 0; i < count; i++)
			{
				participantList.Add(new Participant(i + 1));
			}
		}
		/// <summary>
		/// Моделирует процесс игры
		/// </summary>
		/// <param name="participantList">Список участников</param>
		static void GenerateProcess(List<Participant> participantList)
		{
			int current = 0; //Счётчик для массива
			int counter = 1; //Счётчик для удаления

			while (participantList.Count != 1)
			{
				if (counter == 2)
				{
					Console.WriteLine("Удалён участник под номером {0}", participantList[current].Index);
					participantList.RemoveAt(current);
					counter = 1;
					current--;
				}
				else counter++;

				if (current == participantList.Count - 1)
					current = 0;
				else current++;
			}

			Console.WriteLine("Победил участник под номером {0}", participantList[0].Index);
		}
	}
	/// <summary>
	/// Класс участника игры
	/// </summary>
	class Participant
	{
		/// <summary>
		/// Порядковый номер в игре
		/// </summary>
		public int Index { get; } 
		public Participant(int Index)
		{
			this.Index = Index;
		}
	}
}
