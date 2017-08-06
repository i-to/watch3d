using Watch3D.Core.Debugger;

namespace Watch3D.Package.Debugger
{
    public class TestDebuggeeSymbols : DebuggeeSymbols
    {
        public DebuggeeObjectType MapObjectType(string type)
        {
            switch (type)
            {
                case "Watch3D.Test.Debuggee.Mesh":
                    return DebuggeeObjectType.Mesh;
                case "Watch3D.Test.Debuggee.Polyline":
                    return DebuggeeObjectType.Polyline;
                case "Watch3D.Test.Debuggee.Point":
                    return DebuggeeObjectType.Point;
            }
            throw new EvaluationFailedException($"Unknown debuggee type: '{type}'.");
        }

        public string CreateMeshVerticesExpression(string meshSymbol) =>
            $"DebugInteropStringBuilder.CreateMeshVerticesString({meshSymbol})";

        public string CreateMeshIndicesExpression(string meshSymbol) => 
            $"DebugInteropStringBuilder.CreateMeshIndicesString({meshSymbol})";

        public string CreatePolylinePointsExpression(string symbol) =>
            $"DebugInteropStringBuilder.CreatePolylinePointsString({symbol})";

        public string CreatePointExpression(string symbol) =>
            $"DebugInteropStringBuilder.CreatePointString({symbol})";
    }
}