using System;
using System.IO;
using System.Globalization;
using System.Linq;
using System.Collections.Generic;

namespace BACKUP_SYSTEM.Logging
{
	class Backuper
	{
		/// <summary>
		/// Rolls back all changes in the folder to the specified date
		/// </summary>
		/// <param name="backupTime"></param>
		public void BackupAllFiles(DateTime backupTime)
		{
			var files = Directory.GetFiles(Dependencies.BackupFolder, "*.txt");
			foreach (string path in files)
			{
				BackupFile(path, backupTime);
			}
			BackupDeletedFiles(backupTime);
		}
		/// <summary>
		/// Rolls back file to the specified date
		/// </summary>
		/// <param name="fullPath">File path</param>
		/// <param name="backupTime"></param>
		private void BackupFile(string fullPath, DateTime backupTime)
		{
			string filePath = fullPath.Replace(Dependencies.BackupFolder, "").Replace(".txt", "");
			DirectoryInfo directory = new DirectoryInfo(Dependencies.LogsDirectory + filePath);
			string dateFormat = Dependencies.DateFormat;
			if (directory.Exists) //If file was changed or renamed
			{
				FileInfo[] files = directory.GetFiles("*.txt");
				var validCopies = files.Where(f => DateTime.ParseExact(f.Name.Substring(0, dateFormat.Length), dateFormat, CultureInfo.InvariantCulture) <= backupTime);
				var lastCopy = validCopies.OrderByDescending(f => f.CreationTime).FirstOrDefault();
				if (lastCopy != null) //if file was create
				{
					File.Copy(lastCopy.FullName, fullPath, true);
					string lastCopyName = Path.GetFileNameWithoutExtension(lastCopy.FullName).Substring(dateFormat.Length + 1);
					string fileName = Path.GetFileNameWithoutExtension(fullPath);
					if (lastCopyName != fileName) //if file was renamed
					{
						File.Move(fullPath, fullPath.Replace(fileName, lastCopyName));
						if (!directory.Exists)
							directory
								.MoveTo(directory.FullName
								.Replace(fileName, lastCopyName)
								.Replace(".txt", ""));
					}
				}
				else
				{
					File.Delete(fullPath);
				}
			}
		}
		/// <summary>
		/// Recovers deleted files existing on the specified date
		/// </summary>
		/// <param name="date"></param>
		private void BackupDeletedFiles(DateTime date)
		{
			var directories = Directory.GetDirectories(Dependencies.LogsDirectory, ".", SearchOption.AllDirectories).Where(f => f.Contains("Deleted"));
			string dateFormat = Dependencies.DateFormat;
			foreach (string folder in directories)
			{
				var copiesPaths = Directory.GetFiles(folder);
				var copies = CopiesPathsIntoFileInfo(copiesPaths);
				var lastCopy = copies.
					Where(f => f.CreationTime <= date).
					OrderByDescending(f => f.CreationTime).
					FirstOrDefault();
				if (lastCopy != null)
				{
					string lastCopyName = Path.GetFileNameWithoutExtension(lastCopy.Name)
					.Substring(dateFormat.Length + 1);
					string lastCopyPath = lastCopy.Directory.Parent.FullName.Replace(Dependencies.LogsDirectory, Dependencies.BackupFolder);
					string destPath = Path.Combine(lastCopyPath, lastCopyName) + ".txt";
					DirectoryInfo newDirictory = new DirectoryInfo(lastCopyPath);
					if (!newDirictory.Exists)
						newDirictory.Create();
					File.Copy(lastCopy.FullName, destPath);
				}
			}

		}
		/// <summary>
		/// Returns files at specified paths
		/// </summary>
		/// <param name="paths"></param>
		/// <returns></returns>
		private FileInfo[] CopiesPathsIntoFileInfo(string[] paths)
		{
			List<FileInfo> files = new List<FileInfo>();
			foreach (string path in paths)
			{
				files.Add(new FileInfo(path));
			}
			return files.ToArray();
		}
	}
}
