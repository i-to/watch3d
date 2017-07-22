using System.Windows.Media.Media3D;
using Watch3D.Core.Model;
using Watch3D.Core.Utility;

namespace Watch3D.Core.ViewModel
{
    public class SceneViewModel : Scene
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

        public void InitializeScene()
        {
            SceneItems.Add(new LightSceneItemViewModel(new LightSceneItem()));
            SceneItems.Add(new GridSceneItemViewModel(new GridSceneItem()));
        }

        public void AddMesh(MeshGeometry3D mesh) =>
            SceneItems.Add(
                new MeshSceneItemViewModel(
                    new MeshSceneItem("Mesh", mesh)));

        public void AddPolyline(Point3DCollection points) =>
            SceneItems.Add(
                new PolylineSceneItemViewModel(
                    new PolylineSceneItem("Polyline", points)));

        public void AddPoint(Point3D point) =>
            SceneItems.Add(
                new PointSceneItemViewModel(
                    new PointSceneItem("Point", point)));
    }
}