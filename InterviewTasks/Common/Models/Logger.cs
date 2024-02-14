using System.Text;

public class Logger
{
    private readonly Stream _writer;
    private readonly TimeProvider _timeProvider;

    public Logger(Stream writer, TimeProvider timeProvider)
    {
        _writer = writer;
        _timeProvider = timeProvider;
        Log("Logger initialized");
    }

    public void Log(string str)
    {
        var actual = Encoding.UTF8.GetBytes(string.Format("[{0:dd.MM.yy HH:mm:ss}] {1}\n", _timeProvider.GetLocalNow(), str));
        _writer.Write(actual);
    }
}