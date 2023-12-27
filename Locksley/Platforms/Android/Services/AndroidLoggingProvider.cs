using Microsoft.Extensions.Logging;

namespace Locksley.Services;

public class AndroidLoggingProvider : ILoggerProvider {
    public void Dispose() {
        GC.SuppressFinalize(this);
    }

    public ILogger CreateLogger(string categoryName) {
        categoryName = categoryName.Split('.').Last();
        return new AndroidLogger(categoryName);
    }
}
