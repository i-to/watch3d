﻿namespace Watch3D.Core.Utility
{
    public static class ObjectExtensions
    {
        public static T Cast<T>(this object obj) => (T)obj;
    }
}
