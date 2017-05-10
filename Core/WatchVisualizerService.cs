using Watch3D.VisualizerServices;

namespace Watch3D.Core
{
    public class WatchVisualizerService : VisualizerService
    {
        readonly Scene Scene;

        public WatchVisualizerService(Scene scene)
        {
            Scene = scene;
        }

        public void ShowMesh(InteropMesh interopMesh)
        {
            var mesh = InteropConverter.Convert(interopMesh);
            Scene.Mesh = mesh;
        }
    }
}