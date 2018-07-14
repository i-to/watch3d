using System.Linq;
using System.Windows;
using System.Windows.Media.Media3D;
using Watch3D.Core;
using Watch3D.Core.Model;
using Watch3D.Core.ViewModel;
using Watch3D.Gui;
using Watch3D.Test.Utility;

namespace Watch3D.Test.GuiStandalone
{
    public class Root
    {
        public readonly Window Window;
        public readonly TestGeometry TestGeometry;
        public readonly SceneModule SceneModule;

        public Root()
        {
            var logger = new LoggerDebugOutput();
            SceneModule = new SceneModule(logger);
            TestGeometry = new TestGeometry();
            var debuggerState = new DebuggerStateStub();
            var symbolInterpreter = new SymbolInterpreterStub(logger);
            var commandInterpreter = new CommandInterpreter(logger, SceneModule.SceneViewModel,
                debuggerState, SceneModule.AddSceneItemFromLiteralCommand, symbolInterpreter);
            var stlWriter = new VisualStlSerializer();
            var debugInteropWriter = new DebugInteropSerializer();
            var exporter = new Exporter(logger, stlWriter, debugInteropWriter);
            var toolViewModel = new ToolViewModel(SceneModule.SceneViewModel, 
                commandInterpreter, SceneModule.SceneInitializer, SceneModule.AddGeometryToScene, exporter);
            var control = new ToolView(toolViewModel);
            Window = new Window {Content = control, Title = "Watch 3D standalone GUI test."};
        }

        public void InitializeTestScene()
        {
            AddTestModel(TestModelId.Bunny);
            AddTestModel(TestModelId.Teapot);
            SceneModule.AddGeometryToScene.AddPoint(TestGeometry.CreateTestPoint());
            SceneModule.AddGeometryToScene.AddPolyline(TestGeometry.CreateTestPolyline());
        }

        public void AddTestModel(TestModelId id)
        {
            var group = TestGeometry.LoadTestModel(id);
            var model = group.Children.First();
            var mesh = (MeshGeometry3D)((GeometryModel3D)model).Geometry;
            SceneModule.AddGeometryToScene.AddMesh(mesh);
        }
    }
}
