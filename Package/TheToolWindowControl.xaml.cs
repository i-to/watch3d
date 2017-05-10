using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media.Media3D;
using Watch3D.Core;

namespace Watch3D.Package
{
    public partial class TheToolWindowControl : UserControl
    {
        public Scene Scene { get; }
        public ExpressionReader ExpressionReader { get; }
        public DebuggerState DebuggerState { get; }

        public TheToolWindowControl(Scene scene, ExpressionReader expressionReader, DebuggerState debuggerState)
        {
            Scene = scene;
            ExpressionReader = expressionReader;
            DebuggerState = debuggerState;
            InitializeComponent();
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
                Scene.Mesh = mesh;
                SetStatus("Success", $"Evaluated mesh symbol: '{meshSymbol}'.");
            }
        }
    }
}