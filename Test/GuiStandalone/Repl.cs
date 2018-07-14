using System.Windows;
using System.Windows.Media.Media3D;
using HelixToolkit.Wpf;
using Watch3D.Core.Geometry;
using Watch3D.Core.ViewModel;
using Watch3D.Test.GuiStandalone;

// ReSharper disable once CheckNamespace
public class Repl
{
    public readonly Root Root;
    public AddGeometryToScene AddGeometryToScene => Root.SceneModule.AddGeometryToScene;

    public Repl()
    {
        Root = new Root();
        Root.Window.Visibility = Visibility.Visible;
    }

    public void AddPoint(Point3D point) => AddGeometryToScene.AddPoint(point);
    public void AddMesh(MeshGeometry3D mesh) => AddGeometryToScene.AddMesh(mesh);

    public void AddCube()
    {
        var meshBuilder = new MeshBuilder();
        meshBuilder.AddCube();
        var meshGeometry = meshBuilder.ToMesh();
        AddMesh(meshGeometry);
    }

    public static void Script()
    {
        var repl = new Repl();
        var point = new Point3D(0, 0, 0);
        repl.AddPoint(point);
        repl.AddCube();
        var plane = new Plane3D {Position = new Point3D(1, 1, 1), Normal = new Vector3D(0.33, 0.33, 0.33)};
        repl.AddGeometryToScene.AddPlane(plane);
    }
}