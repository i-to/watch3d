using System.Collections.Generic;
using System.IO;
using System.Windows.Media.Media3D;
using HelixToolkit.Wpf;
using Watch3D.Core.Scene;

namespace Watch3D.Core.Model
{
    public interface SceneItemSerializer
    {
        // This can throw exceptions related to stream usage.
        void Write(Stream stream, SceneItem item);
    }

    // Writes Visual of a scene item in STL format.
    public class VisualStlSerializer : SceneItemSerializer
    {
        public void Write(Stream stream, SceneItem item)
        {
            var exporter = new StlExporter();
            exporter.Export(item.Visual, stream);
        }
    }

    // TODO: generalize common part with in-debuggee interop
    public class DebugInteropSerializer : SceneItemSerializer
    {
        public static readonly string Separator = "|";

        public void Write(Stream stream, SceneItem item)
        {
            using (var writer = new StreamWriter(stream))
                WriteItem(writer, item);
        }

        static void WriteItem(TextWriter writer, SceneItem item)
        {
            var mesh = item as MeshSceneItem;
            if (mesh != null)
            {
                WriteMesh(writer, mesh);
                return;
            }

            var polyline = item as PolylineSceneItem;
            if (polyline != null)
            {
                WritePolyline(writer, polyline);
                return;
            }

            var point = item as PointSceneItem;
            if (point != null)
            {
                WritePoint(writer, point);
                return;
            }

            writer.Write($"Exporting of item of type: {item.GetType()} is not supported.");
        }

        static void WritePoint(TextWriter writer, PointSceneItem point)
        {
            writer.Write("point");
            writer.Write(Separator);
            WritePoint(writer, point.Location);
        }

        static void WritePolyline(TextWriter writer, PolylineSceneItem polyline)
        {
            writer.Write("polyline");
            writer.Write(Separator);
            WritePoints(writer, polyline.Polyline);
        }

        static void WriteMesh(TextWriter writer, MeshSceneItem mesh)
        {
            writer.Write("mesh");
            writer.Write(Separator);
            WritePoints(writer, mesh.Mesh.Positions);
            writer.Write(Separator);
            WriteIndices(writer, mesh.Mesh.TriangleIndices);
        }

        static void WritePoints(TextWriter writer, IEnumerable<Point3D> points)
        {
            bool first = true;
            foreach (var point in points)
            {
                if (first)
                    first = false;
                else
                    writer.Write(" ");
                WritePoint(writer, point);
            }
        }

        static void WritePoint(TextWriter write, Point3D point) =>
            write.Write($"{point.X},{point.Y},{point.Z}");

        static void WriteIndices(TextWriter writer, IEnumerable<int> indices)
        {
            bool first = true;
            foreach (var index in indices)
            {
                if (first)
                    first = false;
                else
                    writer.Write(" ");
                writer.Write(index.ToString());
            }
        }
    }
}