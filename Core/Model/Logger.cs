namespace Watch3D.Core.Model
{
    public interface Logger
    {
        void Info(string message);
        void Warning(string message);
        void Error(string message);
    }
}