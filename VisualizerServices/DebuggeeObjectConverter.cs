namespace Watch3D.VisualizerServices
{
    public interface DebuggeeObjectConverter
    {
        bool TryConvert(out InteropPoints interopPoints, object obj);
        bool TryConvert(out InteropPoint interopPoint, object obj);
        bool TryConvert(out InteropMesh interopMesh, object obj);
    }
}