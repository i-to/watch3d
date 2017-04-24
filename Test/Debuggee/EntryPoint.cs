using System;
using System.Linq;
using HelixToolkit.Wpf;

namespace Debuggee
{
    class EntryPoint
    {
        static Mesh SingleTriangleTest() =>
            MeshGenerator.CreateSingleTriangle();

        static Mesh LoadModelTest()
        {
            var loader = new ModelImporter();
            var group = loader.Load(@"Models\bunny.obj");
            //var group = loader.Load(@"Models\teapot_quads_tex.obj");
            //var group = loader.Load(@"Models\sphere.stl");
            var converter = new MeshConverter();
            var models = converter.Convert(group.Children).ToArray();
            return models[0];
        }

        static void Main(string[] args)
        {
            var mesh = LoadModelTest();
            // Set a breakpoint on the line below and use Watch3D to examine 'mesh' object.
            Console.WriteLine($"Mesh has {mesh.Vertices.Count} vertices and {mesh.Triangles.Count} triangles.");
            Console.ReadLine();
        }
    }
}
