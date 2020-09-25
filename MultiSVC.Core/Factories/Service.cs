using MultiSVC.Core.Helpers;

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
        public ServiceStartMode ServiceStartMode { get; set; }

        public void CheckDeployment()
        {
            IsInstalled = this.IsServiceInstalled();
        }
    }
}