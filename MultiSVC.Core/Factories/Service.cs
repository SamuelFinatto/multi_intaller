using MultiSVC.Core.Helpers;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MultiSVC.Core.Factories
{
    public enum ServiceStartMode
    {
        Disable,
        Auto,
        AutoDelayed,
        Manual
    }
    public class Service : IService
    {
        public string Arguments { get; set; }
        public string DeploymentPath { get; set; }
        public string ExecutablePath { get; set; }
        public bool IsInstalled { get; set; }
        public string ServiceName { get; set; }
        public string ArtifactPath { get; set; }
        public ServiceStartMode ServiceStartMode { get; set; }

        public void CheckDeployment()
        {
            IsInstalled = this.IsServiceInstalled();
        }
    }

    public class ServiceJson
    {
        [JsonProperty("ServiceJson")]
        public List<Service> Services { get; set; }
    }
}