using System.Diagnostics;
using Watch3D.Core.Model;

namespace Watch3D.Test.GuiStandalone
{
    public class LoggerDebugOutput : Logger
    {
        public void Info(string message) =>
            Debug.WriteLine($"Info. {message}");

        public void Warning(string message) =>
            Debug.WriteLine($"Warning. {message}");

        public void Error(string message) =>
            Debug.WriteLine($"ERROR. {message}");
    }
}