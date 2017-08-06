using System.Windows.Media.Media3D;
using Watch3D.Core.Model;
using Watch3D.Core.Utility;

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
            Scene.AddItem(SceneItemFactory.CreateMesh(mesh));

        public void AddPolyline(Point3DCollection points) =>
            Scene.AddItem(SceneItemFactory.CreatePolyline(points));

        public void AddPoint(Point3D point) =>
            Scene.AddItem(SceneItemFactory.CreatePoint(point));
    }

    public class SceneInitializer
    {
        public readonly SceneItemFactory SceneItemFactory;

        public SceneInitializer(SceneItemFactory sceneItemFactory)
        {
            SceneItemFactory = sceneItemFactory;
        }

        public void InitializeScene(SceneViewModel scene)
        {
            scene.AddItem(SceneItemFactory.CreateLight());
            scene.AddItem(SceneItemFactory.CreateGrid());
        }
    }

    public class SceneViewModel
    {
        public ObservableCollectionWithReplace<SceneItemViewModel> SceneItems { get; }
        public SceneItemCollectionAdapter SceneItemsViewportAdapter { get; }

        public SceneViewModel(
            ObservableCollectionWithReplace<SceneItemViewModel> sceneItems,
            SceneItemCollectionAdapter sceneItemsViewportAdapter)
        {
            SceneItems = sceneItems;
            SceneItemsViewportAdapter = sceneItemsViewportAdapter;
        }

        public void AddItem(SceneItemViewModel item) => SceneItems.Add(item);
    }
}