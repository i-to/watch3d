using System;

namespace Watch3D.VisualizerServices
{
    [Serializable]
    public struct InteropPoints
    {
        /// <summary>
        /// Point coordinates array flattened into an array: {x0, y0, z0, x1, y1, z1, ...}.
        /// </summary>
        public readonly double[] PointsData;

        public InteropPoints(double[] pointsData)
        {
            PointsData = pointsData;
        }
    }
}