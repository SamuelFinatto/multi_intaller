using System;

namespace MultiSVCInstaller
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Hello World!");

            MultiSVC.Core.Helpers.ServiceInstaller installer = new MultiSVC.Core.Helpers.ServiceInstaller();

            var result = installer.InstallService(@"C:\Users\samue\AppData\Roaming\uTorrent\uTorrent.exe", "TestingService", "Service DisplayName", "Super description");

            var rresult = installer.UnInstallService("TestingService");
        }
    }
}
