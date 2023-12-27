using Java.Lang;
using Microsoft.Extensions.Logging;
using Enum = System.Enum;
using Exception = System.Exception;
using Logcat = Android.Util.Log;

namespace Locksley.Services;

public class AndroidLogger(string category) : ILogger {
    public void Log<TState>(
        LogLevel logLevel,
        EventId eventId,
        TState state,
        Exception? exception,
        Func<TState, Exception?, string> formatter) {
        var message = formatter(state, exception);
        var throwable = exception != null ? Throwable.FromException(exception) : null;

        _ = (logLevel, throwable) switch {
            (LogLevel.Trace, null) => Logcat.Verbose(category, message),
            (LogLevel.Debug, null) => Logcat.Debug(category, message),
            (LogLevel.Information, null) => Logcat.Info(category, message),
            (LogLevel.Warning, null) => Logcat.Warn(category, message),
            (LogLevel.Error, null) => Logcat.Error(category, message),
            (LogLevel.Critical, null) => Logcat.Wtf(category, message),
            (LogLevel.None, null) => Logcat.Verbose(category, message),

            (LogLevel.Trace, _) => Logcat.Verbose(category, throwable, message),
            (LogLevel.Debug, _) => Logcat.Debug(category, throwable, message),
            (LogLevel.Information, _) => Logcat.Info(category, throwable, message),
            (LogLevel.Warning, _) => Logcat.Warn(category, throwable, message),
            (LogLevel.Error, _) => Logcat.Error(category, throwable, message),
            (LogLevel.Critical, _) => Logcat.Wtf(category, throwable, message),
            (LogLevel.None, _) => Logcat.Verbose(category, throwable, message),

            _ => throw new IndexOutOfRangeException($"LogLevel {Enum.GetName(logLevel)} didn't match any known value"),
        };
    }

    public bool IsEnabled(LogLevel logLevel) {
        return true;
    }

    public IDisposable? BeginScope<TState>(TState state) where TState : notnull {
        return null;
    }
}