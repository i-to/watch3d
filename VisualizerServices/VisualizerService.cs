﻿using System.Runtime.InteropServices;

namespace Watch3D.VisualizerServices
{
    [Guid("d3b4e955-30c6-4f53-a6a7-f6f250d333d3")]
    [ComVisible(true)]
    public interface VisualizerService
    {
        void ShowMesh(InteropMesh mesh);
        void ShowPoints(InteropPoints points);
        void ShowPoint(InteropPoint point);
    }
}
