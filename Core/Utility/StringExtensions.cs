namespace Watch3D.Core.Utility
{
    public static class StringExtensions
    {
        public static bool IsEmpty(this string str) =>
            str == string.Empty;

        public static bool StartsWith(this string str, string substring) =>
            str.IndexOf(substring) == 0;
    }
}