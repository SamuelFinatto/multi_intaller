namespace MultiSVC.Core.Factories
{
    public interface IService
    {
        string Arguments { get; set; }
        string DeploymentPath { get; set; }
        string ExecutablePath { get; set; }
        bool IsInstalled { get; set; }
        string ServiceName { get; set; }
        ServiceStartMode ServiceStartMode { get; set; }

        void CheckDeployment();
    }
}