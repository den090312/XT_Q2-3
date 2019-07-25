using System;
using System.Collections.Generic;

namespace LOST
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.Write("Enter the number of participants: ");
			if (!int.TryParse(Console.ReadLine(), out int N))
			{
				Console.WriteLine("Incorrect data entered.");
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
		/// Fill in the list of participants
		/// </summary>
		/// <param name="participantList">List</param>
		/// <param name="count">Number of participants</param>
		static void GenerateList(List<Participant> participantList, int count)
		{
			for (int i = 0; i < count; i++)
			{
				participantList.Add(new Participant(i + 1));
			}
		}
		/// <summary>
		/// Simulates the game process
		/// </summary>
		/// <param name="participantList">List of participants</param>
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
	/// Game participant
	/// </summary>
	class Participant
	{
		/// <summary>
		/// Order number in the game
		/// </summary>
		public int Index { get; } 
		public Participant(int Index)
		{
			this.Index = Index;
		}
	}
}
