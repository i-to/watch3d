using System.Linq;
using System.Windows;
using System.Windows.Media.Media3D;
using Watch3D.Core.Model;
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
            var sceneItemsFactory = new SceneItemFactory();
            var sceneViewModel = new SceneViewModel(sceneItems, sceneItemCollectionAdapter);
            var symbolInterpreter = new SymbolInterpreterStub();
            var sceneInitializer = new SceneInitializer(sceneItemsFactory);
            var logger = new LoggerDebugOutput();
            var stlWriter = new VisualSTLStreamWriter();
            var debugInteropWriter = new DebugInteropStreamWriter();
            var exporter = new Exporter(logger, stlWriter, debugInteropWriter);
            var toolViewModel = new ToolViewModel(sceneViewModel, symbolInterpreter, sceneInitializer, exporter);
            var control = new ToolView(toolViewModel);
            Window = new Window {Content = control, Title = "Watch 3D standalone GUI test."};
            var addGeometry = new AddGeometryToScene(sceneViewModel, sceneItemsFactory);
            AddTestModelsToScene(addGeometry);
        }

        public void Run()
        {
            Application.Run(Window);
        }

        void AddTestModelsToScene(AddGeometryToScene add)
        {
            AddModel(add, TestModelId.Bunny);
            AddModel(add, TestModelId.Teapot);
            add.AddPoint(TestGeometry.CreateTestPoint());
            add.AddPolyline(TestGeometry.CreateTestPolyline());
        }

        void AddModel(AddGeometryToScene add, TestModelId id)
        {
            var group = TestGeometry.LoadTestModel(id);
            var model = group.Children.First();
            var mesh = (MeshGeometry3D)((GeometryModel3D)model).Geometry;
            add.AddMesh(mesh);
        }
    }
}
