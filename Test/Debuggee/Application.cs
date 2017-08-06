using System;
using System.Linq;
using Watch3D.Test.Utility;

namespace Watch3D.Test.Debuggee
{
    public class Application
    {
        readonly TestGeometry TestGeometry;
        readonly MeshConverter Converter;
        readonly MeshGenerator MeshGenerator;

        public Application()
        {
            TestGeometry = new TestGeometry();
            Converter = new MeshConverter();
            MeshGenerator = new MeshGenerator();
        }

        public Mesh LoadModel(TestModelId id)
        {
            var group = TestGeometry.LoadTestModel(id);
            var models = Converter.Convert(group.Children).ToArray();
            return models[0];
        }

        public Polyline LoadArc()
        {
            var points = TestGeometry.CreateTestPolyline();
            var convertedPoints = Converter.Convert(points);
            return new Polyline { Points = convertedPoints };
        }

        public Point LoadPoint()
        {
            var point = TestGeometry.CreateTestPoint();
            return Converter.Convert(point);
        }

        public void Run()
        {
            var triangle = MeshGenerator.CreateSingleTriangle();
            var sphere = LoadModel(TestModelId.Sphere);
            var teapot = LoadModel(TestModelId.Teapot);
            var bunny = LoadModel(TestModelId.Bunny);
            var arc = LoadArc();
            var point = LoadPoint();
            // Set a breakpoint on the line below and use Watch3D to examine object.
            var count = 
                triangle.Triangles.Count
                + sphere.Triangles.Count
                + teapot.Triangles.Count
                + bunny.Triangles.Count;
            Console.WriteLine($"Loaded {count} triangles.");
            Console.WriteLine($"Loaded polyline with {arc.Points.Count} points.");
            Console.WriteLine($"Loaded point at ({point.X}, {point.Y}, {point.Z}).");
            Console.ReadLine();
        }
    }
}