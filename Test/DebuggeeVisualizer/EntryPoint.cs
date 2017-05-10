using Microsoft.VisualStudio.DebuggerVisualizers;
using Microsoft.VisualStudio.Shell;
using Watch3D.VisualizerServices;

namespace Watch3D.Test.DebuggeeVisualizer
{
    public class EntryPoint : DialogDebuggerVisualizer
    {
        protected override void Show(IDialogVisualizerService windowService, IVisualizerObjectProvider objectProvider)
        {
            var visualizerService = (VisualizerService)Package.GetGlobalService(typeof(VisualizerService));
            var mesh = (InteropMesh)objectProvider.GetObject();
            visualizerService.ShowMesh(mesh);
        }
    }
}
