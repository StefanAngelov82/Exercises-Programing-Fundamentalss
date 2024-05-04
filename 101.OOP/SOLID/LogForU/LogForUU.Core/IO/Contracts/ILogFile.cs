namespace LogForUU.Core.IO.Contracts
{
    public interface ILogFile
    {
        string Name { get; }
        string Path { get; }
        int size { get; }
        string Content { get; }
        void Write(string text);
    }
}
