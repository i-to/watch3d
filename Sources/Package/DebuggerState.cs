using EnvDTE;
using EnvDTE100;

namespace Watch3D.Package
{
    public class DebuggerState
    {
        readonly Debugger5 Debugger;

        public DebuggerState(Debugger5 debugger)
        {
            Debugger = debugger;
        }

        public bool IsBreakMode => Debugger.CurrentMode == dbgDebugMode.dbgBreakMode;
    }
}
