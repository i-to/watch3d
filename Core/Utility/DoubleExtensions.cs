using System;

namespace Watch3D.Core.Utility
{
    public static class DoubleExtensions
    {
        public static double Tolerance = 1e-8;

        public static bool IsNearlyZero(this double value) =>
            Math.Abs(value) < Tolerance;
    }
}
