using System;

namespace BACKUP_SYSTEM.Logging
{
	static class Dependencies
	{
		/// <summary>
		/// The path in which logging will be performed
		/// </summary>
		public static string LogsDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\FileWatcher\LOGS\";
		/// <summary>
		/// The folder to be tracked
		/// </summary>
		public const string BackupFolder = @"C:\Test\";
		/// <summary>
		/// Basic date format (for logging)
		/// </summary>
		public const string DateFormat = "dd.MM.yyyy-HH.mm.ss";
	}
}
