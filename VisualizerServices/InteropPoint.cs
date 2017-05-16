using System;

namespace Watch3D.VisualizerServices
{
    [Serializable]
    public struct InteropPoint
    {
        public readonly double X, Y, Z;

        public InteropPoint(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }
    }
}