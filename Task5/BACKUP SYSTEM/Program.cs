using BACKUP_SYSTEM.Logging;
using System;
using System.Globalization;
using System.IO;

namespace BACKUP_SYSTEM
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
			
			while (true)
			{
				Console.WriteLine("Select an operating mode:\n" +
								"1) Observer Mode\n" +
								"2) Rollback mode");
				Console.Write("Input: ");
				if (int.TryParse(Console.ReadLine(), out int input) && input > 0 && input < 3)
				{
					switch (input)
					{
						case 1:
							var watcher = new FileWatcher();
							watcher.FileAction += OnFileChanged;
							Console.WriteLine("To exit observer mode, click Q");
							while (true)
							{
								ConsoleKeyInfo key = Console.ReadKey(true);
								if (key.Key == ConsoleKey.Q) break;
							}
							break;
						case 2:
							var backuper = new Backuper();
							string dateFormat = "dd.MM.yyyy HH:mm:ss";
							Console.Write($"Enter date in format {dateFormat}: ");
							if (DateTime.TryParseExact(Console.ReadLine(), dateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime result))
								backuper.BackupAllFiles(result);
							else Console.WriteLine("Date entered incorrectly.");
							break;
					}
				}
				else Console.WriteLine("Data entered incorrectly");
			}
		}
		/// <summary>
		/// Output to the console information about file changes
		/// </summary>
		/// <param name="arg1">Change type</param>
		/// <param name="arg2">File name</param>
		private static void OnFileChanged(WatcherChangeTypes arg1, string arg2)
		{
			switch (arg1)
			{
				case WatcherChangeTypes.Created:
					Console.WriteLine($"File {arg2} was created.");
					break;
				case WatcherChangeTypes.Deleted:
					Console.WriteLine($"File {arg2} was deleted.");
					break;
				case WatcherChangeTypes.Changed:
					Console.WriteLine($"File {arg2} was changed.");
					break;
				case WatcherChangeTypes.Renamed:
					Console.WriteLine($"File {arg2} was renamed.");
					break;
			}
		}
	}
}
