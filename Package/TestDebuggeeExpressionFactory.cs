using Watch3D.Core;
using Watch3D.Core.Debugger;

namespace Watch3D.Package
{
    public class TestDebuggeeExpressionFactory : ExpressionFactory
    {
        public string CreateMeshVerticesExpression(string meshSymbol) =>
            $"MeshStringBuilder.GetVerticesString({meshSymbol})";

        public string CreateMeshIndicesExpression(string meshSymbol) => 
            $"MeshStringBuilder.GetIndicesString({meshSymbol})";
    }
}