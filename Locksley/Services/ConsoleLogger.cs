using Microsoft.Extensions.Logging;

namespace Locksley.Services;

public class ConsoleLogger(string category) : ILogger {

    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter) {
        var message = formatter(state, exception);
        Console.WriteLine($@"{logLevel}: {category}: {message}");
    }

    public bool IsEnabled(LogLevel logLevel) => true;

    public IDisposable BeginScope<TState>(TState state) where TState : notnull => null;
}