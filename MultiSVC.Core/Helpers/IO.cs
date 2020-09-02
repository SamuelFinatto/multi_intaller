using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MultiSVC.Core.Helpers
{
    public static class IO
    {
        public static bool CheckFolderAccess(string folderPath)
        {
            var logger = NLog.LogManager.GetCurrentClassLogger();

            if (!Directory.Exists(folderPath))
                return false;

            try
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(folderPath);
                var folderName = directoryInfo.Name;
                var date = DateTime.Now.ToString("hhmmss");
                directoryInfo.RenameTo($"{folderName}.{date}");
                logger.Info("Folder is enable to access");
                directoryInfo.RenameTo(folderName);
                return true;
            }
            catch(Exception ex)
            {
                logger.Error(ex, "Folder unable to be accessed.");
                return false;
            }
        }

        public static void RenameTo(this DirectoryInfo di, string name)
        {
            if (di == null)
            {
                throw new ArgumentNullException("di", "Directory info to rename cannot be null");
            }

            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("New name cannot be null or blank", "name");
            }

            di.MoveTo(Path.Combine(di.Parent.FullName, name));

            return; //done
        }
    }
}
