using System;
using System.Linq;
using Watch3D.Test.Utility;

namespace Watch3D.Test.Debuggee
{
    class EntryPoint
    {
        static Mesh LoadModel(TestModelId id)
        {
            var testModels = new TestGeometry();
            var group = testModels.LoadTestModel(id);
            var converter = new MeshConverter();
            var models = converter.Convert(group.Children).ToArray();
            return models[0];
        }

        static void Main(string[] args)
        {
            var triangle = MeshGenerator.CreateSingleTriangle();
            var sphere = LoadModel(TestModelId.Sphere);
            var teapot = LoadModel(TestModelId.Teapot);
            var bunny = LoadModel(TestModelId.Bunny);
            // Set a breakpoint on the line below and use Watch3D to examine 'mesh' object.
            var count = 
                triangle.Triangles.Count
              + sphere.Triangles.Count
              + teapot.Triangles.Count
              + bunny.Triangles.Count;
            Console.WriteLine($"Loaded {count} triangles.");
            Console.ReadLine();
        }
    }
}
