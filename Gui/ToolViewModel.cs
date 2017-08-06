using System.Collections.Generic;
using Watch3D.Core.Utility;
using Watch3D.Core.ViewModel;

namespace Watch3D.Gui
{
    public class ToolViewModel
    {
        public SceneViewModel Scene { get; }
        public SymbolInterpreter SymbolInterpreter { get; }
        public SceneInitializer SceneInitializer { get; }

        public ToolViewModel(SceneViewModel scene, SymbolInterpreter symbolInterpreter, SceneInitializer sceneInitializer)
        {
            Scene = scene;
            SymbolInterpreter = symbolInterpreter;
            SceneInitializer = sceneInitializer;
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
    }
}
