using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MultiSVC.Core.Factories
{
    public enum StepTypes
    {
        CheckVersion,
        Deploy,
        Uninstall,
        MoveOnly
    }

    public interface IStep
    {
        ValueTask Start(CancellationToken ct = default);
    }

    public class Step : IStep
    {
        public StepTypes StepType { get; set; }
        public List<string> ArtifactPaths { get; set; }

        public async ValueTask Start(CancellationToken ct = default)
        {
            switch (StepType)
            {
                case StepTypes.CheckVersion:
                    break;
            }
        }
    }
}