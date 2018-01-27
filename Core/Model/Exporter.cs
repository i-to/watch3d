using System;
using System.IO;
using System.Text.RegularExpressions;
using HelixToolkit.Wpf;
using Microsoft.Win32;

namespace Watch3D.Core.Model
{
    public class Exporter
    {
        readonly string DialogFilterSTL = "STL file (*.stl)|*.stl";

        public void Export(SceneItem item)
        {
            var fullName = AskExportFullPathViaDialog(item);
            if (fullName == null)
                return;
            TryExport(item, fullName);
        }

        void TryExport(SceneItem item, string fullName)
        {
            try
            {
                using (var stream = File.Create(fullName))
                {
                    var exporter = new StlExporter();
                    exporter.Export(item.Visual, stream);
                }
            }
            catch (Exception exception)
            when (exception is UnauthorizedAccessException
               || exception is PathTooLongException
               || exception is DirectoryNotFoundException
               || exception is IOException
               || exception is NotSupportedException)
            {
                // TODO: error reporting
            }
        }

        string AskExportFullPathViaDialog(SceneItem item)
        {
            var dialog = new SaveFileDialog
            {
                Filter = DialogFilterSTL,
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