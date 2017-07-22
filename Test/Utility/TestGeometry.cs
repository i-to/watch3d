using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Media.Media3D;
using HelixToolkit.Wpf;

namespace Watch3D.Test.Utility
{
    public enum TestModelId { Bunny, Sphere, Teapot }
    
    public class TestGeometry
    {
        public Model3DGroup LoadTestModel(TestModelId id)
        {
            var fileName = ModelFileName(id);
            var path = Path.Combine("Models", fileName);
            var loader = new ModelImporter();
            return loader.Load(path);
        }

        string ModelFileName(TestModelId id)
        {
            switch (id)
            {
            case TestModelId.Bunny:
                return "bunny.obj";
            case TestModelId.Sphere:
                return "sphere.stl";
            case TestModelId.Teapot:
                return "teapot_quads_tex.obj";
            }
            throw new ArgumentException($"Unknown model id: {id}.");
        }

        public Point3D CreateTestPoint() => new Point3D(1.0, 1.0, 5.0);
        public Point3DCollection CreateTestPolyline() => new Point3DCollection(CreateArc());

        IEnumerable<Point3D> CreateArc()
        {
            for (int i = 0; i != 100; ++i)
            {
                var angle = 0.03 * i;
                yield return new Point3D()
                           + new Vector3D(5, 0, 0) * Math.Sin(angle)
                           + new Vector3D(0, 6, 0) * Math.Cos(angle);
            }
        }
    }
}
