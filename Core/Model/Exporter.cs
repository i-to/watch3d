using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Media.Media3D;
using HelixToolkit.Wpf;
using Microsoft.Win32;

namespace Watch3D.Core.Model
{
    public interface SceneItemStreamWriter
    {
        // This can throw exceptions related to stream usage.
        void Write(Stream stream, SceneItem item);
    }

    // Writes Visual of a scene item in STL format.
    public class VisualSTLStreamWriter : SceneItemStreamWriter
    {
        public void Write(Stream stream, SceneItem item)
        {
            var exporter = new StlExporter();
            exporter.Export(item.Visual, stream);
        }
    }

    // TODO: generalize common part with in-debuggee interop
    public class DebugInteropStreamWriter : SceneItemStreamWriter
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

    public class Exporter
    {
        readonly string DialogFilterSTL = "STL file (*.stl)|*.stl";
        readonly string DialogFilterWatch3D = "Watch3D file (*.watch3d)|*.watch3d";

        readonly Logger Logger;
        readonly VisualSTLStreamWriter STLWriter;
        readonly DebugInteropStreamWriter DebugInteropWriter;

        public Exporter(Logger logger, VisualSTLStreamWriter stlWriter, DebugInteropStreamWriter debugInteropWriter)
        {
            Logger = logger;
            STLWriter = stlWriter;
            DebugInteropWriter = debugInteropWriter;
        }

        public void TryExport(SceneItem item)
        {
            TryExportSceneItem(item, DialogFilterWatch3D, DebugInteropWriter);
        }

        public void TryExportSTL(SceneItem item) =>
            TryExportSceneItem(item, DialogFilterSTL, STLWriter);

        public void TryExportSceneItem(SceneItem item, string dialogFilter, SceneItemStreamWriter writer)
        {
            var fullName = AskExportFullPathViaDialog(item, dialogFilter);
            if (fullName == null)
                return;
            try
            {
                using (var stream = File.Create(fullName))
                    writer.Write(stream, item);
            }
            catch (Exception exception)
            when (exception is UnauthorizedAccessException
               || exception is PathTooLongException
               || exception is DirectoryNotFoundException
               || exception is IOException
               || exception is NotSupportedException)
            {
                Logger.Error($"Failed to export file to path: ${fullName}.\nError details: '{exception}'.");
            }
        }

        string AskExportFullPathViaDialog(SceneItem item, string dialogFilter)
        {
            var dialog = new SaveFileDialog
            {
                Filter = dialogFilter,
                FileName = CreateDefaultFileName(item.Name)
            };
            if (dialog.ShowDialog() != true)
                return null;
            var fullName = dialog.FileName;
            if (fullName == "")
                return null;
            return fullName;
        }

        string CreateDefaultFileName(string itemName)
        {
            var regexSearch = new string(Path.GetInvalidFileNameChars());
            var regex = new Regex($"[{Regex.Escape(regexSearch)}]");
            return regex.Replace(itemName, "_");
        }
    }
}