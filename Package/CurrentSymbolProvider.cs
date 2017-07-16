using EnvDTE;
using EnvDTE80;

namespace Watch3D.Package
{
    public class CurrentSymbolProvider
    {
        readonly DTE2 Dte;

        public CurrentSymbolProvider(DTE2 dte)
        {
            Dte = dte;
        }

        public string GetSelectedSymbol()
        {
            var document = Dte.ActiveDocument;
            var textDocument = document.Object("TextDocument") as TextDocument;
            var selection = textDocument.Selection;
            //var virtualPoint = selection.ActivePoint;
            return selection.Text;
        }
    }
}