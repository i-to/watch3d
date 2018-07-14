using System;
using System.IO;
using System.Text.RegularExpressions;
using Microsoft.Win32;
using Watch3D.Core.Scene;

namespace Watch3D.Core.Model
{
    public class Exporter
    {
        readonly string DialogFilterSTL = "STL file (*.stl)|*.stl";
        readonly string DialogFilterWatch3D = "Watch3D file (*.watch3d)|*.watch3d";

        readonly Logger Logger;
        readonly VisualStlSerializer STLWriter;
        readonly DebugInteropSerializer DebugInteropWriter;

        public Exporter(Logger logger, VisualStlSerializer stlWriter, DebugInteropSerializer debugInteropWriter)
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

        public void TryExportSceneItem(SceneItem item, string dialogFilter, SceneItemSerializer writer)
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