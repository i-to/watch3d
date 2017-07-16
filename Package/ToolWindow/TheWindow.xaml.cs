using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Watch3D.Core.Scene;
using Watch3D.Core.Utility;

namespace Watch3D.Package.ToolWindow
{
    public partial class TheToolWindowControl : UserControl
    {
        public SymbolInterpreter SymbolInterpreter { get; }
        public SceneViewModel Scene { get; }

        public TheToolWindowControl(
            SceneViewModel scene,
            SymbolInterpreter symbolInterpreter)
        {
            Scene = scene;
            SymbolInterpreter = symbolInterpreter;
            InitializeComponent();
            scene.InitializeScene();
        }

        void ExecuteDelete(object sender, ExecutedRoutedEventArgs e)
        {
            var indices = e.GetSource<ListBox>().GetSelectedItemIndices();
            Scene.SceneItems.RemoveAtEach(indices);
        }

        void ExecuteToggleShowHide(object sender, ExecutedRoutedEventArgs e)
        {
            var listBox = e.GetSource<ListBox>();
            var indices = listBox.GetSelectedItemIndices();
            foreach (var index in indices)
                Scene.SceneItems.Modify(index, item => item.ToggleVisibility());
            listBox.ResetSelection(indices);
        }

        void ExecuteStartEditing(object sender, ExecutedRoutedEventArgs e)
        {
            var listBoxItem = e.GetSource<ListBox>().GetFocusedItemContainer();
            ToolWindow.EditableTextBox.FindInParent(listBoxItem).StartEditing();
        }

        void SetStatus(string title, string subtitle)
        {
            Viewport.Title = title;
            Viewport.SubTitle = subtitle;
        }

        void Add(object sender, RoutedEventArgs e)
        {
            var status = SymbolInterpreter.TryAddSceneItemFromSymbol(MeshSymbol.Text);
            SetStatus(status.Item1, status.Item2);
        }
    }
}