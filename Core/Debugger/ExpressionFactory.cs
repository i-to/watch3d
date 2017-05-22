namespace Watch3D.Core.Debugger
{
    public interface ExpressionFactory
    {
        string CreateMeshVerticesExpression(string meshSymbol);
        string CreateMeshIndicesExpression(string meshSymbol);
    }
}