using System;
using System.IO;
using System.Threading;

namespace MultiSVC.Core.Helpers
{
    public static class IO
    {
        private static readonly NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public static bool CheckFolderAccess(string folderPath)
        {
            if (!Directory.Exists(folderPath))
                return false;

            try
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(folderPath);
                var folderName = directoryInfo.Name;
                var date = DateTime.Now.ToString("hhmmss");
                directoryInfo.RenameTo($"{folderName}_{date}");
                Thread.Sleep(10);
                directoryInfo.RenameTo(folderName);
                logger.Info("Folder is able to access");
                return true;
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Folder unable to be accessed.");
                return false;
            }
        }

        public static void RenameTo(this DirectoryInfo di, string name)
        {
            logger.Info($"Renaming {di.Name} to {name}");
            if (di == null)
                throw new ArgumentNullException("di", "Directory info to rename cannot be null");

            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("New name cannot be null or blank", "name");

            di.MoveTo(Path.Combine(di.Parent.FullName, name));
            logger.Info("Rename OK.");
        }

        public static bool MoveFolder(string source, string dest, bool overwrite)
        {
            if (string.IsNullOrWhiteSpace(source) || string.IsNullOrWhiteSpace(dest))
                throw new ArgumentException("parameters cannot be null or blank");

            try
            {
                logger.Info($"Moving {source} to {dest}...");
                if (overwrite && Directory.Exists(dest))
                    Directory.Delete(dest);

                Directory.Move(source, dest);
                logger.Info($"{source} moved to {dest}");
            }
            catch (IOException ex)
            {
                logger.Error(ex, $"Error when moving {source}");
                return false;
            }
            return true;
        }

        public static bool DeleteFolder(string path)
        {
            if (!Directory.Exists(path))
            {
                logger.Error($"folder {path} does not exist.");
                return false;
            }

            logger.Info($"Checking {path} access...");
            if (!CheckFolderAccess(path))
            {
                logger.Error($"folder {path} not able to be deleted, is being used.");
                return false;
            }

            Directory.Delete(path);
            logger.Info($"folder {path} removed");
            return true;
        }
    }
}