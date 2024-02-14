using Microsoft.Extensions.Time.Testing;
using System.Text;
using Xunit.Abstractions;

namespace InterviewTask2
{
    public class LoggerUnitTests
    {
        private readonly ITestOutputHelper output;

        public LoggerUnitTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void Log_WhenLogged_ShouldReturnLoggedString()
        {
            var Memory = new MemoryStream();
            var fakeTimeProvider = new FakeTimeProvider();
            fakeTimeProvider.SetUtcNow(new DateTime(2023, 11, 5));

            var logger = new Logger(Memory, fakeTimeProvider);

            var str = "Hello from Kiran";
            logger.Log(str);
            string actual = Encoding.UTF8.GetString(Memory.ToArray());
            string expected = $"{string.Format("[{0:dd.MM.yy HH:mm:ss}] {1}", fakeTimeProvider.GetLocalNow(), "Logger initialized")}\n{string.Format("[{0:dd.MM.yy HH:mm:ss}] {1}", fakeTimeProvider.GetLocalNow(), str)}\n";
            output.WriteLine(expected);
            Assert.Equal(expected, actual);

        }
    }
}