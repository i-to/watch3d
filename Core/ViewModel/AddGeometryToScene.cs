using System.Windows.Media.Media3D;
using HelixToolkit.Wpf;
using Watch3D.Core.Model;

namespace Watch3D.Core.ViewModel
{
    public class AddGeometryToScene : VisualizerAddGeometry
    {
        public readonly SceneViewModel Scene;
        public readonly SceneItemFactory SceneItemFactory;

        public AddGeometryToScene(SceneViewModel scene, SceneItemFactory sceneItemFactory)
        {
            Scene = scene;
            SceneItemFactory = sceneItemFactory;
        }

        public void AddMesh(MeshGeometry3D mesh) =>
            Scene.AddItem(
                SceneItemFactory.CreateMesh("mesh", mesh));

        public void AddPolyline(Point3DCollection points) =>
            Scene.AddItem(
                SceneItemFactory.CreatePolyline("polyline", points));

        public void AddPoint(Point3D point) =>
            Scene.AddItem(
                SceneItemFactory.CreatePoint("point", point));

        public void AddPlane(Plane3D plane) =>
            Scene.AddItem(
                SceneItemFactory.CreatePlane("plane", plane));
    }
}