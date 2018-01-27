using System;
using System.Windows.Media.Media3D;
using Watch3D.Core.ViewModel;

namespace Watch3D.Core.Model
{
    public class SceneItemDeserializer
    {
        public InteropParser Parser { get; }
        public SceneItemFactory SceneItemFactory { get; }

        public SceneItemDeserializer(InteropParser parser, SceneItemFactory sceneItemFactory)
        {
            Parser = parser;
            SceneItemFactory = sceneItemFactory;
        }

        public SceneItemViewModel Deserialize(string name, string data)
        {
            var tokens = data.Split('|');
            if (tokens.Length < 2)
                throw new FormatException($"Failed to parse evaluated expression: '{data}'");
            var objectType = tokens[0];

            switch (objectType)
            {
            case "mesh":
                if (tokens.Length < 3)
                    throw new FormatException("Expected object in the following format: 'mesh|<vertex data>|<triangles data>'");
                var mesh = new MeshGeometry3D
                {
                    Positions = Parser.ParsePoint3DCollection(tokens[1]),
                    TriangleIndices = Parser.ParseInt32Collection(tokens[2])
                };
                return SceneItemFactory.CreateMesh(name, mesh);

            case "triangle":
                var triangle = new MeshGeometry3D
                {
                    Positions = Parser.ParsePoint3DCollection(tokens[1]),
                    TriangleIndices = Parser.ParseInt32Collection("0, 1, 2")
                };
                return SceneItemFactory.CreateMesh(name, triangle);

            case "polyline":
                var polyline = Parser.ParsePoint3DCollection(tokens[1]);
                return SceneItemFactory.CreatePolyline(name, polyline);

            case "point":
                var point = Parser.ParsePoint3D(tokens[1]);
                return SceneItemFactory.CreatePoint(name, point);
            }

            throw new FormatException($"Unknown object type: {objectType}");
        }
    }
}