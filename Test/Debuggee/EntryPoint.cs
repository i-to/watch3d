using System;
using System.Linq;
using HelixToolkit.Wpf;

namespace Watch3D.Test.Debuggee
{
    class EntryPoint
    {
        static Mesh LoadModel(string name)
        {
            var loader = new ModelImporter();
            var group = loader.Load($"Models\\{name}");
            var converter = new MeshConverter();
            var models = converter.Convert(group.Children).ToArray();
            return models[0];
        }

        static void Main(string[] args)
        {
            var triangle = MeshGenerator.CreateSingleTriangle();
            var sphere = LoadModel("sphere.stl");
            var teapot = LoadModel("teapot_quads_tex.obj");
            var bunny = LoadModel("bunny.obj");
            // Set a breakpoint on the line below and use Watch3D to examine 'mesh' object.
            var count = triangle.Triangles.Count + sphere.Triangles.Count + teapot.Triangles.Count + bunny.Triangles.Count;
            Console.WriteLine($"Loaded {count} triangles.");
            Console.ReadLine();
        }
    }
}
