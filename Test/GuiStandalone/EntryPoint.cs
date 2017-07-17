using System;
using System.Windows;
using Watch3D.Core.Scene;
using Watch3D.Core.Utility;
using Watch3D.Gui;

namespace Watch3D.Test.GuiStandalone
{
    public class SymbolInterpreterStub : SymbolInterpreter
    {
        public Tuple<string, string> TryAddSceneItemFromSymbol(string meshSymbol) =>
            Tuple.Create("STUB", "STUB");
    }

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
            application.Run(window);
        }
    }
}
