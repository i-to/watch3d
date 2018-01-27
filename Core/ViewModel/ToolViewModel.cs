using System.Collections.Generic;
using Watch3D.Core.Model;
using Watch3D.Core.Utility;

namespace Watch3D.Core.ViewModel
{
    public class ToolViewModel
    {
        public SceneViewModel Scene { get; }
        public SymbolInterpreter SymbolInterpreter { get; }
        public SceneInitializer SceneInitializer { get; }
        public Exporter Exporter { get; }

        public ToolViewModel(
            SceneViewModel scene,
            SymbolInterpreter symbolInterpreter,
            SceneInitializer sceneInitializer,
            Exporter exporter)
        {
            Scene = scene;
            SymbolInterpreter = symbolInterpreter;
            SceneInitializer = sceneInitializer;
            Exporter = exporter;
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

        public void TryAddItemBySymbolName(string symbol) =>
            SymbolInterpreter.TryAddItemBySymbolName(symbol);

        public void Export(int sceneItemIndex)
        {
            var item = Scene.GetItem(sceneItemIndex);
            Exporter.TryExport(item.Model);
        }

        public void ExportSTL(int sceneItemIndex)
        {
            var item = Scene.GetItem(sceneItemIndex);
            Exporter.TryExportSTL(item.Model);
        }
    }
}
