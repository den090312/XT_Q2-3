using System;
using System.IO;

namespace BACKUP_SYSTEM.Logging
{
	class Logger
	{

		#region Constructors
		public Logger()
		{
			CreateLogsFolder();
		}
		#endregion

		/// <summary>
		/// Creates a log folder
		/// </summary>
		private void CreateLogsFolder()
		{
			DirectoryInfo directory = new DirectoryInfo(Dependencies.LogsDirectory);
			if (!directory.Exists)
				directory.Create();
			else
			{
				directory.Delete(true);
				directory.Create();
			}
		}
		/// <summary>
		/// Creates a log of a modified or created file by the date it was modified or created
		/// </summary>
		/// <param name="fullPath"></param>
		/// <param name="fileName"></param>
		/// <param name="date"></param>
		public void SaveChangedOrCreatedFileLog(string fullPath, string fileName, DateTime date)
		{
			//For folder
			if (Path.GetExtension(fileName) == "")
			{
				DirectoryInfo directory = new DirectoryInfo(Dependencies.LogsDirectory + $@"\{fileName}\");
				if (!directory.Exists)
				{
					directory.Create();
				}
			}
			else //For file
			{
				string dateStr = date.ToString(Dependencies.DateFormat);
				string fileNameWithoutExt = fileName.Replace(Path.GetExtension(fileName), "");
				DirectoryInfo directory = new DirectoryInfo(Dependencies.LogsDirectory + $@"\{fileNameWithoutExt}\");
				if (!directory.Exists)
				{
					directory.Create();
				}
				string newFileDir = directory.FullName + $@"{dateStr}-{Path.GetFileName(fileName)}";
				try
				{
					if (!File.Exists(newFileDir))
						File.Copy(fullPath, newFileDir);
				}
				catch 
				{
					return;
				}
			}
		}
		/// <summary>
		/// Creates a log of a renamed file by rename date
		/// </summary>
		/// <param name="newFullPath"></param>
		/// <param name="oldFileName"></param>
		/// <param name="newFileName"></param>
		/// <param name="date"></param>
		public void SaveRenamedFileLog(string newFullPath, string oldFileName, string newFileName, DateTime date)
		{
			//For folder
			if (Path.GetExtension(newFileName) == "")
			{
				DirectoryInfo directory = new DirectoryInfo(Dependencies.LogsDirectory + $@"\{oldFileName}\");
				string destDirectory = Dependencies.LogsDirectory + $@"\{newFileName}\";
				if (directory.Exists)
				{
					directory.MoveTo(destDirectory);
				}
			}
			else //For file
			{
				string dateStr = date.ToString(Dependencies.DateFormat);
				string oldFileNameWithoutExt = oldFileName.Replace(Path.GetExtension(oldFileName), "");
				string newFileNameWithoutExt = newFileName.Replace(Path.GetExtension(newFileName), "");
				DirectoryInfo directory = new DirectoryInfo(Dependencies.LogsDirectory + $@"\{oldFileNameWithoutExt}\");
				string destDirectory = Dependencies.LogsDirectory + $@"\{newFileNameWithoutExt}\";
				if (directory.Exists)
				{
					directory.MoveTo(destDirectory);
				}
				string newFileDir = destDirectory + $@"{dateStr}-{Path.GetFileName(newFileName)}";
				DirectoryInfo newDir = new DirectoryInfo(newFileDir);
				if (!newDir.Parent.Exists)
					newDir.Parent.Create();
				if (!File.Exists(newFileDir))
					File.Copy(newFullPath, newFileDir);
			}
		}
		/// <summary>
		/// Creates a log of a deleted file by delete date
		/// </summary>
		/// <param name="newFullPath"></param>
		/// <param name="oldFileName"></param>
		/// <param name="newFileName"></param>
		/// <param name="date"></param>
		public void SaveDeletedFileLog(string fullPath, string fileName, DateTime date)
		{
			string dateStr = date.ToString(Dependencies.DateFormat);
			//For folder
			if (Path.GetExtension(fileName) == "")
			{
				DirectoryInfo directory = new DirectoryInfo(Dependencies.LogsDirectory + $@"\{fileName}\");
				string destDirectory = Dependencies.LogsDirectory + $@"\Deleted-{dateStr}-{fileName}\";
				if (directory.Exists)
				{
					directory.MoveTo(destDirectory);
				}
			}
			else //For file
			{
				string fileNameWithoutExt = fileName.Replace(Path.GetExtension(fileName), "");
				DirectoryInfo directory = new DirectoryInfo(Dependencies.LogsDirectory + $@"\{fileNameWithoutExt}\");

				string newPath = fileNameWithoutExt.Replace(Path.GetFileNameWithoutExtension(fileName), "");
				string newFolderName = Path.GetFileNameWithoutExtension(fileName);
				string destDirectory = Dependencies.LogsDirectory + $@"{newPath}\Deleted-{dateStr}-{newFolderName}\";
				if (directory.Exists)
				{
					directory.MoveTo(destDirectory);
				}
			}
		}
	}
}
