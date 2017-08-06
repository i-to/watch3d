namespace Watch3D.Core.Debugger
{
    public enum DebuggeeObjectType
    {
        Mesh,
        Polyline,
        Point
    }

    public interface DebuggeeSymbols
    {
        DebuggeeObjectType MapObjectType(string type);
        string CreateMeshVerticesExpression(string meshSymbol);
        string CreateMeshIndicesExpression(string meshSymbol);
        string CreatePointExpression(string symbol);
        string CreatePolylinePointsExpression(string symbol);
    }
}