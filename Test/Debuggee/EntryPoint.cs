using System;

namespace Debuggee
{
    class EntryPoint
    {
        static void Main(string[] args)
        {
            var mesh = MeshGenerator.CreateSingleTriangle();
            // Set a breakpoint on the line below and use Watch3D to examine 'mesh' object.
            Console.WriteLine($"Generated mesh with {mesh.Vertices.Count} vertices and {mesh.Triangles.Count} triangles.");
            Console.ReadLine();
        }
    }
}
