using System.Windows.Media.Media3D;

namespace Watch3D.Core
{
    public class Scene
    {
        readonly ExpressionReader ExpressionReader;
        readonly DebuggerState DebuggerState;

        public Scene(ExpressionReader expressionReader, DebuggerState debuggerState)
        {
            ExpressionReader = expressionReader;
            DebuggerState = debuggerState;
        }

        public string Title { get; private set; } = "Empty";
        public string Subtitle { get; private set; } = "";
        public MeshGeometry3D Mesh { get; private set; }

        void SetStatus(string title, string subtitle)
        {
            Title = title;
            Subtitle = subtitle;
        }

        public void Update(string meshSymbol)
        {
            if (meshSymbol.IsEmpty())
                return;
            if (!DebuggerState.IsBreakMode)
            {
                SetStatus("ERROR:", "Cannot read mesh symbol while not in break mode");
                return;
            }
            Mesh = ExpressionReader.TryReadMesh(meshSymbol);
            if (Mesh == null)
            {
                SetStatus("ERROR:", $"Failed to read mesh object: '{meshSymbol}'.");
                return;
            }
            SetStatus("Mesh object:", meshSymbol);
        }

        public void UpdateByVisualizer(MeshGeometry3D mesh)
        {
            Mesh = mesh;
            SetStatus("Mesh", "Set by visualizer service");
        }
    }
}