namespace Watch3D.Core
{
    public interface ExpressionFactory
    {
        string CreateMeshVerticesExpression(string meshSymbol);
        string CreateMeshIndicesExpression(string meshSymbol);
    }
}