using System;

namespace Watch3D.VisualizerServices
{
    [Serializable]
    public struct InteropMesh
    {
        /// <summary>
        /// Vertex coordinates array flattened into an array: {x0, y0, z0, x1, y1, z1, ...}.
        /// </summary>
        public readonly double[] VertexData;

        /// <summary>
        /// Triangles as indices into vertex array flattened out: {a0, b0, c0, a1, b1, c1, ...}.
        /// Indices point into the array of vertices, not the flattened array of coordinates.
        /// </summary>
        public readonly int[] TrianglesData;

        public InteropMesh(double[] vertexData, int[] trianglesData)
        {
            VertexData = vertexData;
            TrianglesData = trianglesData;
        }
    }
}
