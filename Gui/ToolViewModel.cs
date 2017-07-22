using System;
using System.Collections.Generic;
using Watch3D.Core.Model;
using Watch3D.Core.Utility;
using Watch3D.Core.ViewModel;

namespace Watch3D.Gui
{
    public class ToolViewModel
    {
        public SceneViewModel Scene { get; }
        public SymbolInterpreter SymbolInterpreter { get; }

        public ToolViewModel(SceneViewModel scene, SymbolInterpreter symbolInterpreter)
        {
            Scene = scene;
            SymbolInterpreter = symbolInterpreter;
        }

        public void DeleteSceneItems(IReadOnlyList<int> indices) =>
            Scene.SceneItems.RemoveAtEach(indices);

        public void ToggleSceneItemsVisibility(IReadOnlyList<int> indices)
        {
            foreach (var index in indices)
                Scene.SceneItems.Modify(index, item => item.ToggleVisibility());
        }

        public Tuple<string, string> TryAddItemBySymbolName(string symbol) =>
            SymbolInterpreter.TryAddItemBySymbolName(symbol);
    }
}
