﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using MultiSVC.Core.Helpers;
using System;
using System.IO;

namespace MultiSVC.Tests
{
    [TestClass]
    public class IOTests
    {
        [TestMethod]
        public void CheckFolderAccess_insertnull_returnFalse()
        {
            var result = IO.CheckFolderAccess(null);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CheckFolderAccess_insertvalidFolder_returnTrue()
        {
            var folderinfo = Directory.CreateDirectory(Path.Combine(Path.GetTempPath(), $"folder{DateTime.Now:hhmmss}"));
            var result = IO.CheckFolderAccess(folderinfo.FullName);
            Assert.IsTrue(result);
        }

        [TestMethod]
        [Ignore("Azure DevOps is taking issues with that")]
        public void CheckFolderAccess_insertvalidFolderWithFileOpen_returnFalse()
        {
            var folderinfo = Directory.CreateDirectory(Path.Combine(Path.GetTempPath(), $"folder{DateTime.Now:hhmmss}"));
            bool result = false;
            using (FileStream fs = File.Open(Path.Combine(folderinfo.FullName, "file"), FileMode.OpenOrCreate, FileAccess.Write, FileShare.None))
            {
                result = IO.CheckFolderAccess(folderinfo.FullName);
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