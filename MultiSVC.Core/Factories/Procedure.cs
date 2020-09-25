using System;
using System.Collections.Generic;
using System.Text;

namespace MultiSVC.Core.Factories
{
    public enum ProcedureType
    {
        Install,
        Uninstall,
        Update
    }

    public class Procedure
    {
        public ProcedureType ProcedureType { get; set; }
        public IService Service { get; set; }
        public List<IStep> Steps { get; set; }
    }
}
