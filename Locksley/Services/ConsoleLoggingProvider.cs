using Microsoft.Extensions.Logging;

namespace Locksley.Services;

public class ConsoleLoggingProvider : ILoggerProvider {
    public void Dispose() {
        GC.SuppressFinalize(this);
    }

    public ILogger CreateLogger(string categoryName) => new ConsoleLogger(categoryName);
}