using System.Linq;
using System.Windows;
using System.Windows.Media.Media3D;
using Watch3D.Core.Utility;
using Watch3D.Core.ViewModel;
using Watch3D.Gui;
using Watch3D.Test.Utility;

namespace Watch3D.Test.GuiStandalone
{
    public class App
    {
        readonly Application Application;
        readonly Window Window;
        readonly TestGeometry TestGeometry;

        public App()
        {
            TestGeometry = new TestGeometry();
            Application = new Application();
            var sceneItems = new ObservableCollectionWithReplace<SceneItemViewModel>();
            var sceneItemCollectionAdapter = new SceneItemCollectionAdapter(sceneItems);
            var sceneViewModel = new SceneViewModel(sceneItems, sceneItemCollectionAdapter);
            var symbolInterpreter = new SymbolInterpreterStub();
            var toolViewModel = new ToolViewModel(sceneViewModel, symbolInterpreter);
            var control = new ToolView(toolViewModel);
            Window = new Window {Content = control, Title = "Watch 3D standalone GUI test."};
            AddTestModelsToScene(sceneViewModel);
        }

        public void Run()
        {
            Application.Run(Window);
        }

        void AddTestModelsToScene(SceneViewModel sceneViewModel)
        {
            AddModel(sceneViewModel, TestModelId.Bunny);
            AddModel(sceneViewModel, TestModelId.Teapot);
            sceneViewModel.AddPoint(TestGeometry.CreateTestPoint());
            sceneViewModel.AddPolyline(TestGeometry.CreateTestPolyline());
        }

        void AddModel(SceneViewModel scene, TestModelId id)
        {
            var group = TestGeometry.LoadTestModel(id);
            var model = group.Children.First();
            var mesh = (MeshGeometry3D)((GeometryModel3D)model).Geometry;
            scene.AddMesh(mesh);
        }
    }
}
