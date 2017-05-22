using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Watch3D.Core.Debugger;
using Watch3D.Core.Scene;
using Watch3D.Core.Utility;
using Watch3D.Package.Utility;

namespace Watch3D.Package
{
    public partial class TheToolWindowControl : UserControl
    {
        public SceneViewModel Scene { get; }
        public ExpressionReader ExpressionReader { get; }
        public DebuggerState DebuggerState { get; }

        public TheToolWindowControl(
            SceneViewModel scene,
            ExpressionReader expressionReader,
            DebuggerState debuggerState)
        {
            Scene = scene;
            ExpressionReader = expressionReader;
            DebuggerState = debuggerState;
            InitializeComponent();
            scene.InitializeScene();
        }

        void Delete(object sender, ExecutedRoutedEventArgs e)
        {
            var indices = ((ListBox)e.Source).GetSelectedItemIndices();
            Scene.SceneItems.RemoveAtEach(indices);
        }

        void ToggleShowHide(object sender, ExecutedRoutedEventArgs e)
        {
            var sceneItems = Scene.SceneItems;
            var listBox = (ListBox)e.Source;
            var indices = listBox.GetSelectedItemIndices();
            foreach (var index in indices)
                sceneItems.Modify(index, item => item.ToggleVisibility());
            listBox.ResetSelection(indices);
        }

        void SetStatus(string title, string subtitle)
        {
            Viewport.Title = title;
            Viewport.SubTitle = subtitle;
        }

        void Add(object sender, RoutedEventArgs e)
        {
            if (!DebuggerState.IsBreakMode)
            {
                SetStatus("ERROR", "Cannot evaluate expression while not in break mode.");
                return;
            }
            var meshSymbol = MeshSymbol.Text;
            var mesh = ExpressionReader.TryReadMesh(meshSymbol);
            if (mesh == null)
            {
                SetStatus("ERROR", $"Failed to evaluate mesh symbol: '{meshSymbol}'.");
            }
            else
            {
                Scene.AddMesh(mesh);
                SetStatus("Success", $"Evaluated mesh symbol: '{meshSymbol}'.");
            }
        }
    }
}