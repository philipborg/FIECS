using Fody;
using System.Collections.Generic;

namespace FIECS.Compile.Fody
{
    public class ModuleWeaver : BaseModuleWeaver
    {
        public override void Execute()
        {
        }

        public override IEnumerable<string> GetAssembliesForScanning()
        {
            yield return "netstandard";
            yield return "mscorlib";
        }

        public override bool ShouldCleanReference => true;
    }
}