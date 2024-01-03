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

        switch (logLevel) {
#pragma warning disable CS8604 // Possible null reference argument.
            case LogLevel.Trace:       Logcat.Verbose(category, throwable, message); break;
            case LogLevel.Debug:       Logcat.Debug(category, throwable, message); break;
            case LogLevel.Information: Logcat.Info(category, throwable, message); break;
            case LogLevel.Warning:     Logcat.Warn(category, throwable, message); break;
            case LogLevel.Error:       Logcat.Error(category, throwable, message); break;
            case LogLevel.Critical:    Logcat.Wtf(category, throwable, message); break;
#pragma warning restore CS8604 // Possible null reference argument.
            
            case LogLevel.None: break; 
            
            default: throw new IndexOutOfRangeException($"LogLevel {Enum.GetName(logLevel)} didn't match any known value");
        }
    }

    public bool IsEnabled(LogLevel logLevel) {
        return true;
    }

    public IDisposable BeginScope<TState>(TState state) where TState : notnull => default!;
}