namespace Zork
{
    public interface IOutputService
    {
        void Write(object value);
        void Write(string value);
        void WriteLine(string value);
        void WriteLine(object value);
        void Clear();
    }
}
