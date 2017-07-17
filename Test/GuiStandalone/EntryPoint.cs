using System;
using System.Linq;
using System.Windows;
using System.Windows.Media.Media3D;
using Watch3D.Core.Scene;
using Watch3D.Core.Utility;
using Watch3D.Gui;
using Watch3D.Test.Utility;

namespace Watch3D.Test.GuiStandalone
{
    public static class EntryPoint
    {
        [STAThread]
        public static void Main()
        {
            var application = new Application();
            var sceneItems = new ObservableCollectionWithReplace<SceneItemViewModel>();
            var sceneItemCollectionAdapter = new SceneItemCollectionAdapter(sceneItems);
            var sceneViewModel = new SceneViewModel(sceneItems, sceneItemCollectionAdapter);
            var symbolInterpreter = new SymbolInterpreterStub();
            var control = new ToolWindowControl(sceneViewModel, symbolInterpreter);
            var window = new Window {Content = control};
            AddModel(sceneViewModel, TestModelId.Bunny);
            AddModel(sceneViewModel, TestModelId.Teapot);
            application.Run(window);
        }

        static void AddModel(SceneViewModel scene, TestModelId id)
        {
            var testModels = new TestModels();
            var group = testModels.LoadTestModel(id);
            var model = group.Children.First();
            var mesh = (MeshGeometry3D)((GeometryModel3D)model).Geometry;
            scene.AddMesh(mesh);
        }
    }
}
