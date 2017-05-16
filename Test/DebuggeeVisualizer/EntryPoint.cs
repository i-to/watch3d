using System;
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
            var obj = objectProvider.GetObject();
            if (obj is InteropMesh)
            {
                var mesh = (InteropMesh)obj;
                visualizerService.ShowMesh(mesh);
            }
            else if (obj is InteropPoints)
            {
                var points = (InteropPoints)obj;
                visualizerService.ShowPoints(points);
            }
            else if (obj is InteropPoint)
            {
                var point = (InteropPoint)obj;
                visualizerService.ShowPoint(point);
            }
            else
            {
                throw new ArgumentException($"Unrecognized object type: {obj.GetType()}");
            }
        }
    }
}
