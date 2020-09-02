using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using MultiSVC.Core.Helpers;

namespace MultiSVC.Tests
{
    [TestClass]
    public class IOTests
    {
        [TestMethod]
        public void CheckFolderAccess_insertnull_returnFalse()
        {
            var result = MultiSVC.Core.Helpers.IO.CheckFolderAccess(null);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CheckFolderAccess_insertvalidFolder_returnTrue()
        {
            var folderinfo = Directory.CreateDirectory(Path.Combine(Path.GetTempPath(), $"folder{DateTime.Now:hhmmss}"));
            var result = MultiSVC.Core.Helpers.IO.CheckFolderAccess(folderinfo.FullName);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CheckFolderAccess_insertvalidFolderWithFileOpen_returnFalse()
        {
            var folderinfo = Directory.CreateDirectory(Path.Combine(Path.GetTempPath(), $"folder{DateTime.Now:hhmmss}"));
            bool result = false;
            using (FileStream fs = File.Open(Path.Combine(folderinfo.FullName,"file.file"), FileMode.OpenOrCreate, FileAccess.Write, FileShare.None))
            {
                Byte[] info = new UTF8Encoding(true).GetBytes("This is some text in the file.");

                result = MultiSVC.Core.Helpers.IO.CheckFolderAccess(folderinfo.FullName);
                // Add some information to the file.
                fs.Write(info, 0, info.Length);
            }
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void RenameTo_InsertCorrectString_RenameOK()
        {
            var folderinfo = Directory.CreateDirectory(Path.Combine(Path.GetTempPath(), $"folder{DateTime.Now:hhmmss}"));
            folderinfo.RenameTo($"folderrrr{DateTime.Now:hhmmss}");
        }

        [TestMethod]
        public void RenameTo_InsertNull_Fail()
        {
            var folderinfo = Directory.CreateDirectory(Path.Combine(Path.GetTempPath(), $"folder{DateTime.Now:hhmmss}"));
            Assert.ThrowsException<ArgumentException>(() => folderinfo.RenameTo(null));
        }
    }
}
