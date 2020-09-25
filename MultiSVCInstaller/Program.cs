using MultiSVC.Core.Factories;
using Newtonsoft.Json;
using NLog.Layouts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace MultiSVCInstaller
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Hello World!");

            var jsonString = File.ReadAllText("ServicesConfig.json");

            
            var services = JsonConvert.DeserializeObject<ServiceJson>(jsonString).Services;

        }
    }
}
 