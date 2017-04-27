using Watch3D.Core;

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