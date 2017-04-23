namespace Watch3D.Package
{
    public static class StringExtensions
    {
        public static int ParseInt32(this string str) => int.Parse(str);
        public static double ParseDouble(this string str) => double.Parse(str);
    }
}