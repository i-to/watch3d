using System.Windows;
using System.Windows.Controls;
using Watch3D.Core;

namespace Watch3D.Package
{
    public partial class TheToolWindowControl : UserControl
    {
        readonly Scene Scene;

        public TheToolWindowControl(Scene scene)
        {
            Scene = scene;
            InitializeComponent();
        }

        void EvaluateButton_OnClick(object sender, RoutedEventArgs e)
        {
            Scene.Update(MeshSymbol.Text);
            Viewport.Title = Scene.Title;
            Viewport.SubTitle = Scene.Subtitle;
            Model.Geometry = Scene.Mesh;
            Viewport.ZoomExtents();
        }
    }
}