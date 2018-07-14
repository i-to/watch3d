using System.Collections.Generic;
using System.Windows.Media.Media3D;
using Watch3D.Core.Model;
using Watch3D.Core.Utility;

namespace Watch3D.Core.ViewModel
{
    public class ToolViewModel
    {
        public SceneViewModel Scene { get; }
        public CommandInterpreter CommandInterpreter { get; }
        public SceneInitializer SceneInitializer { get; }
        public AddGeometryToScene AddGeometryToScene { get; }
        public Exporter Exporter { get; }

        public ToolViewModel(
            SceneViewModel scene,
            CommandInterpreter commandInterpreter,
            SceneInitializer sceneInitializer,
            AddGeometryToScene addGeometryToScene,
            Exporter exporter)
        {
            Scene = scene;
            CommandInterpreter = commandInterpreter;
            SceneInitializer = sceneInitializer;
            Exporter = exporter;
            AddGeometryToScene = addGeometryToScene;
        }

        public void InitializeScene() =>
            SceneInitializer.InitializeScene(Scene);

        public void DeleteSceneItems(IReadOnlyList<int> indices) =>
            Scene.SceneItems.RemoveAtEach(indices);

        public void ToggleSceneItemsVisibility(IReadOnlyList<int> indices)
        {
            foreach (var index in indices)
                Scene.SceneItems.Modify(index, item => item.ToggleVisibility());
        }

        public void ExecuteTextCommand(string command) =>
            CommandInterpreter.Execute(command);

        public void ExportItem(int sceneItemIndex)
        {
            var item = Scene.GetItem(sceneItemIndex);
            Exporter.TryExport(item.Model);
        }

        public void ExportItemAsSTL(int sceneItemIndex)
        {
            var item = Scene.GetItem(sceneItemIndex);
            Exporter.TryExportSTL(item.Model);
        }

        public void ExecuteAddPoint() => 
            AddGeometryToScene.AddPoint(new Point3D());
    }
}
