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
            var mesh = InteropConverter.ConvertMesh(interopMesh);
            Scene.AddMesh(mesh);
        }

        public void ShowPoints(InteropPoints interopPoints)
        {
            var points = InteropConverter.ConvertPoints(interopPoints);
            Scene.AddPolyline(points);
        }

        public void ShowPoint(InteropPoint interopPoint)
        {
            var point = InteropConverter.ConvertPoint(interopPoint);
            Scene.AddPoint(point);
        }
    }
}