using System;
using System.IO;

namespace BACKUP_SYSTEM.Logging
{
	class FileWatcher
	{
		private readonly Logger logger;

		private readonly FileSystemWatcher watcher;
		/// <summary>
		/// An event that is raised when a file is acted upon.
		/// </summary>
		public event Action<WatcherChangeTypes, string> FileAction;

		public FileWatcher()
		{
			watcher = new FileSystemWatcher(Dependencies.BackupFolder)
			{
				EnableRaisingEvents = true,
				IncludeSubdirectories = true
			};
			logger = new Logger();
			watcher.IncludeSubdirectories = true;
			watcher.Changed += OnFileChanged;
			watcher.Created += OnFileCreated;
			watcher.Renamed += OnFileRenamed;
			watcher.Deleted += OnFileDeleted;
		}

		private void OnFileDeleted(object sender, FileSystemEventArgs e)
		{
			watcher.EnableRaisingEvents = false;
			logger.SaveDeletedFileLog(e.FullPath, e.Name, DateTime.Now);
			watcher.EnableRaisingEvents = true;
			FileAction?.Invoke(WatcherChangeTypes.Deleted, e.Name);
		}

		private void OnFileRenamed(object sender, RenamedEventArgs e)
		{
			watcher.EnableRaisingEvents = false;
			logger.SaveRenamedFileLog(e.FullPath, e.OldName, e.Name, DateTime.Now);
			watcher.EnableRaisingEvents = true;
			FileAction?.Invoke(WatcherChangeTypes.Renamed, e.Name);
		}

		private void OnFileCreated(object sender, FileSystemEventArgs e)
		{
			watcher.EnableRaisingEvents = false;
			logger.SaveChangedOrCreatedFileLog(e.FullPath, e.Name, DateTime.Now);
			watcher.EnableRaisingEvents = true;
			FileAction?.Invoke(WatcherChangeTypes.Created, e.Name);
		}

		private void OnFileChanged(object sender, FileSystemEventArgs e)
		{
			watcher.EnableRaisingEvents = false;
			logger.SaveChangedOrCreatedFileLog(e.FullPath, e.Name, DateTime.Now);
			watcher.EnableRaisingEvents = true;
			FileAction?.Invoke(WatcherChangeTypes.Changed, e.Name);
		}

	}
}
