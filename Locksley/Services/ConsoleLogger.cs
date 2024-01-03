using Locksley.Services.Logging;
using Microsoft.Extensions.Logging;

namespace Locksley.Services;

public class ConsoleLogger(string category) : ILogger {
    private LoggingScope? _scope; 
    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter) {
        var message = formatter(state, exception);
        Console.WriteLine($@"{logLevel}: {_scope?.ToString() ?? ""}{category}: {message}");
    }

    public bool IsEnabled(LogLevel logLevel) => true;

    public IDisposable BeginScope<TState>(TState state) where TState : notnull {
        if (_scope is not null && !_scope.IsDisposed) {
            return new LoggingScope<TState>(state, _scope);
        }

        _scope = new LoggingScope<TState>(state);
        return _scope;
    }
}
