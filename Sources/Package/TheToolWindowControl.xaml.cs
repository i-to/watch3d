using System.Windows;
using System.Windows.Controls;

namespace Watch3D.Package
{
    public partial class TheToolWindowControl : UserControl
    {
        readonly ExpressionReader ExpressionReader;
        readonly DebuggerState DebuggerState;

        public TheToolWindowControl(
            ExpressionReader expressionReader,
            DebuggerState debuggerState)
        {
            ExpressionReader = expressionReader;
            DebuggerState = debuggerState;
            InitializeComponent();
        }

        void SetStatus(string title, string subtitle)
        {
            Viewport.Title = title;
            Viewport.SubTitle = subtitle;
        }

        void EvaluateButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (!DebuggerState.IsBreakMode)
            {
                SetStatus("ERROR:", "Cannot read mesh symbol while not in break mode");
                return;
            }
            var geometry = ExpressionReader.TryReadMesh(MeshSymbol.Text);
            if (geometry == null)
            {
                SetStatus("ERROR:", $"Failed to read mesh object: '{MeshSymbol.Text}'.");
                return;
            }
            Model.Geometry = geometry;
            Viewport.ZoomExtents();
            SetStatus("Mesh object:", MeshSymbol.Text);
        }
    }
}