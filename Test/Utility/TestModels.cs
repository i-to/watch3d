using System;
using System.IO;
using System.Windows.Media.Media3D;
using HelixToolkit.Wpf;

namespace Watch3D.Test.Utility
{
    public enum TestModelId { Bunny, Sphere, Teapot }
    
    public class TestModels
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
            case TestModelId.Bunny:  return "bunny.obj";
            case TestModelId.Sphere: return "sphere.stl";
            case TestModelId.Teapot: return "teapot_quads_tex.obj";
            }
            throw new ArgumentException($"Unknown model id: {id}.");
        }
    }
}
