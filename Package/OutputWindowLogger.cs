using System;
using Microsoft.VisualStudio.Shell.Interop;
using Watch3D.Core.Model;

namespace Watch3D.Package
{
    public class OutputWindowLogger : Logger
    {
        readonly Guid PaneGuid = new Guid("44b8c4b4-6276-4469-b13e-1235872cde50");
        readonly string PaneTitle = "Watch 3D";
        readonly IVsOutputWindowPane Pane;

        public OutputWindowLogger(IVsOutputWindow outputWindowService)
        {
            Pane = CreatePane(outputWindowService, PaneGuid, PaneTitle);
        }

        static IVsOutputWindowPane CreatePane(IVsOutputWindow outputWindowService, Guid guid, string title)
        {
            outputWindowService.CreatePane(ref guid, title, Convert.ToInt32(true), Convert.ToInt32(false));
            IVsOutputWindowPane pane;
            outputWindowService.GetPane(ref guid, out pane);
            return pane;
        }

        void WriteMessageWithTimeStamp(string message) =>
            Pane.OutputString($"{DateTime.Now}\n{message}\n");

        public void Info(string message) =>
            WriteMessageWithTimeStamp(message);

        public void Warning(string message) =>
            WriteMessageWithTimeStamp("Warning. " + message);

        public void Error(string message) =>
            WriteMessageWithTimeStamp("ERROR. " + message);
    }
}
