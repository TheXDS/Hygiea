using System;

namespace TheXDS.Hygiea.Models
{
    public class OptionPayload
    {
        public Guid OptionId { get; set; }
        public string OptionName { get; set; }
        public Guid[] Requires { get; set; }
        public Guid[] BlockedBy { get; set; }
        public bool Required { get; set; }
        public long PayloadSize { get; set; }
        public string PathSuffix { get; set; }
        public string[] PathVarDirs { get; set; }
        public ProgramShortcut[] Shortcuts { get; set; }
        public RuntimeDependency[] Dependencies { get; set; }
    }
}
